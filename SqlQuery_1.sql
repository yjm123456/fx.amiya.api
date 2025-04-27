WITH t1 AS (
	SELECT
		a.id,
		DATE_FORMAT( a.send_date, '%Y-%m-%d' ) send_date,
	IF
		( support_emp_id <> 0, support_emp_id, belong_emp_id ) employee_id,
		content_plateform_id,
		a.live_anchor_id,
	CASE
			
			WHEN b.live_anchor_id IN ( SELECT a.id FROM tbl_live_anchor a LEFT JOIN tbl_live_anchor_base_info b ON a.live_anchor_base_id = b.id WHERE nick_name = '刀刀' ) THEN
			'刀刀' 
			WHEN b.live_anchor_id IN ( SELECT a.id FROM tbl_live_anchor a LEFT JOIN tbl_live_anchor_base_info b ON a.live_anchor_base_id = b.id WHERE nick_name = '吉娜' ) THEN
			'吉娜' ELSE 'cooperation_anchor' 
		END anchor_group,
	b.wechat_no,
	phone,
	add_order_price,
	appointment_hospital_id,
	is_main_hospital,
	order_status,
	customer_source,
	belong_channel,
	consultation_type 
FROM
	tbl_content_platform_order a
	LEFT JOIN tbl_live_anchor_wechat_info b ON a.live_anchor_we_chat_no = b.id
	LEFT JOIN ( SELECT content_platform_order_id, max( is_main_hospital ) is_main_hospital FROM tbl_content_platform_order_send GROUP BY content_platform_order_id ) c ON a.id = c.content_platform_order_id 
WHERE
	a.send_date IS NOT NULL 
	),
	t2 AS (
		WITH t1 AS (
		SELECT
			DATE_FORMAT( record_date, '%Y-%m-%d' ) record_date,
		CASE
				
				WHEN a.base_liveanchor_id = 'f0a77257-c905-4719-95c4-ad2c4f33855c' THEN
				'刀刀' 
				WHEN a.base_liveanchor_id = 'af69dcf5-f749-41ea-8b50-fe685facdd8b' THEN
				'吉娜' ELSE 'cooperation_anchor' 
			END anchor_group,
IF
	( phone = 00000000000 && LENGTH( sub_phone ) = 11, sub_phone, phone ) phone 
FROM
	tbl_shopping_cart_registration a 
	),
	t2 AS ( SELECT ROW_NUMBER() over ( PARTITION BY anchor_group, phone ORDER BY record_date ASC ) rank_asc, t1.* FROM t1 ) SELECT
	* 
FROM
	t2 
WHERE
	rank_asc = 1 
	),
	t3 AS (
	SELECT
	IF
		(
			t2.record_date IS NULL,
			"未能查询结果",
		IF
		( t2.record_date <= t1.send_date, t2.record_date, "登记早于派单" )) record_date,
	IF
		(
			t2.record_date <= t1.send_date,
		IF
			(
				YEAR ( t2.record_date ) = YEAR ( t1.send_date ) && MONTH ( t2.record_date ) = MONTH ( t1.send_date ),
				"当月",
				"历史" 
			),
			"历史" 
		) 当月历史,
		t1.id,
		t1.send_date,
		employee_id,
		content_plateform_id,
		live_anchor_id,
		wechat_no,
		t1.phone,
		add_order_price,
		appointment_hospital_id,
		is_main_hospital,
		order_status,
		customer_source,
		belong_channel,
		consultation_type 
	FROM
		t1
		LEFT JOIN t2 ON t1.phone = t2.phone && t1.anchor_group = t2.anchor_group 
	ORDER BY
		send_date DESC 
	),
	t4 AS (
SELECT DISTINCT
		a.id,
	  b.price before_price,
		DATE_FORMAT(b.create_date,"%Y-%m-%d") before_create_date,
		DATE_FORMAT(d.create_date,"%Y-%m-%d") after_create_date,
	  a.last_deal_info_id,
		a.content_platform_order_id,
		DATE_FORMAT( a.create_date, '%Y-%m-%d' ) create_date,
		a.is_to_hospital,
		a.is_deal,
		a.price,
		a.last_deal_hospital_id,
		a.is_old_customer,
		DATE_FORMAT( a.to_hospital_date, '%Y-%m-%d' ) to_hospital_date,
		DATE_FORMAT( a.deal_date, '%Y-%m-%d' ) deal_date,
		a.deal_performance_type ,
		a.valid 
	FROM
		tbl_content_platform_order_deal_info a 
		LEFT JOIN 
		tbl_content_platform_order_deal_info b 
		on a.last_deal_info_id = b.id 
		LEFT JOIN
		tbl_content_platform_order_deal_info d 
		on a.id = d.last_deal_info_id
	WHERE
		a.content_platform_order_id IS NOT NULL /*&& a.valid = 1 */&& NOT EXISTS (
		SELECT
			* 
		FROM
			tbl_content_platform_order_deal_info c 
		WHERE
			c.create_date > '2024-07-01' && c.last_deal_hospital_id IN ( 16, 37 )&& a.id = c.id
		) 
	) SELECT
	t3.record_date,
IF
	(
		t3.当月历史 = "历史",
		"历史",
	IF
		( YEAR ( create_date ) = YEAR ( send_date ) && MONTH ( create_date ) = MONTH ( send_date ), "当月", "历史" ) 
	)当月历史,
	t4.*,
	t3.send_date,
	t3.employee_id,
	t3.content_plateform_id,
	t3.live_anchor_id,
	t3.wechat_no,
	t3.phone,
	t3.add_order_price,
	t3.is_main_hospital,
	t3.customer_source,
	t3.belong_channel,
	consultation_type,
IF
	( t4.last_deal_hospital_id IS NULL, t3.appointment_hospital_id, t4.last_deal_hospital_id ) last_deal_hospital_id_correction 
FROM
	t4
	LEFT JOIN t3 ON t4.content_platform_order_id = t3.id