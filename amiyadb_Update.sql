

----------------------------------------------王健 2024/1/4 BEGIN----------------------------------------
---员工表添加提成信息
ALTER TABLE `tbl_amiya_employee`
	ADD COLUMN `new_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `bind_base_live_anchor_id`,
	ADD COLUMN `old_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `new_customer_commission`,
	ADD COLUMN `inspection_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `old_customer_commission`;

---助理薪资表添加字段
ALTER TABLE `tbl_customer_service_compensation`
	ADD COLUMN `salary` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `remark`,
	ADD COLUMN `customer_service_performance` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `salary`,
	ADD COLUMN `to_hospital_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `customer_service_performance`,
	ADD COLUMN `to_hospital_rate_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `to_hospital_rate`,
	ADD COLUMN `repeat_purchases_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `to_hospital_rate_reword`,
	ADD COLUMN `repeat_purchases_rate_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `repeat_purchases_rate`,
	ADD COLUMN `new_customer_to_hospital_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `repeat_purchases_rate_reword`,
	ADD COLUMN `old_customer_to_hospital_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `new_customer_to_hospital_reword`,
	ADD COLUMN `target_finish_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `old_customer_to_hospital_reword`,
	ADD COLUMN `other_chargebacks` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `target_finish_reword`;

----------------------------------------------王健 2024/1/4 END----------------------------------------
 
----------------------------------------------余建明 2024/1/4 BEGIN----------------------------------------
--助理薪资审核新增提成点数与提成业绩
 ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `performance_percent` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `customer_service_compensation_id`,
ADD COLUMN `customer_service_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `performance_percent`;
----------------------------------------------余建明 2024/1/4 END----------------------------------------




------------------------------------------王健  2024/1/18 BEGIN------------------------------------------
---职位信息添加字段
ALTER TABLE `tbl_amiya_position_info`
	ADD COLUMN `read_self_liveanchor_data` BIT NOT NULL AFTER `read_live_anchor_data`,
	ADD COLUMN `read_cooperate_liveanchor_data` BIT NOT NULL AFTER `read_self_liveanchor_data`,
	ADD COLUMN `read_take_goods_data` BIT NOT NULL AFTER `read_cooperate_liveanchor_data`;

------------------------------------------王健  2024/1/18 END------------------------------------------


----------------------------------------王健  2024/1/19 BEGIN------------------------------------------


---员工表添加行政客服提成信息
ALTER TABLE `tbl_amiya_employee`
	ADD COLUMN `administrative_inspection_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `inspection_commission`,
	ADD COLUMN `cooperate_liveanchor_new_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `administrative_inspection_commission`,
	ADD COLUMN `cooperate_liveanchor_old_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `cooperate_liveanchor_new_customer_commission`,
	ADD COLUMN `tmall_order_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `cooperate_liveanchor_old_customer_commission`;


----------------------------------------王健  2024/1/19 END------------------------------------------


----------------------------------------------余建明 2024/1/22 BEGIN----------------------------------------
--对账单审核记录新增行政客服审核薪资模块数据
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `check_type` INT NOT NULL DEFAULT 0 AFTER `compensation_check_state`,
ADD COLUMN `is_inspect_performance` BIT(1) NOT NULL DEFAULT 0 AFTER `check_belong_empid`,
ADD COLUMN `inspect_empid` INT NULL AFTER `is_inspect_performance`,
ADD COLUMN `inspect_percent` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_empid`,
ADD COLUMN `inspect_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_empid`,
ADD COLUMN `inspect_customer_service_compensation_id` VARCHAR(50) NULL AFTER `customer_service_compensation_id`,
ADD COLUMN `customer_service_order_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_customer_service_compensation_id`;

--生成薪资新增行政客服板块业务
ALTER TABLE `amiyadb`.`tbl_customer_service_compensation` 
ADD COLUMN `beauty_add_wechat_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `other_chargebacks`,
ADD COLUMN `take_goods_add_wechat_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `beauty_add_wechat_price`,
ADD COLUMN `consulation_card_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `take_goods_add_wechat_price`,
ADD COLUMN `consulation_card_add_wechat_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `consulation_card_price`,
ADD COLUMN `cooperation_live_anchor_send_order_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `consulation_card_add_wechat_price`,
ADD COLUMN `cooperation_live_anchor_to_hospital_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cooperation_live_anchor_send_order_price`;

----------------------------------------------余建明 2024/1/26 END----------------------------------------


----------------------------------------王健  2024/1/25 BEGIN------------------------------------------

---直播前月目标添加抖音 线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `tiktok_clues_target` INT NOT NULL DEFAULT 0 AFTER `tik_tok_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_tiktok_clues` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues_target`,
	ADD COLUMN `tiktok_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_clues`,
	ADD COLUMN `tiktok_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues_complete_rate`,
	ADD COLUMN `cumulative_tiktok_increase_fans` INT NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_target`,
	ADD COLUMN `tiktok_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_increase_fans`,
	ADD COLUMN `tiktok_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_tiktok_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees_target`,
	ADD COLUMN `tiktok_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_increase_fans_fees`;



---直播前月目标添加小红书  线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `xiaohongshu_showcase_income_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income_target`,
	ADD COLUMN `xiaohongshu_showcase_income_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_showcase_income`,
	ADD COLUMN `xiaohongshu_clues_target` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_clues` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues_target`,
	ADD COLUMN `xiaohongshu_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_clues`,
	ADD COLUMN `xiaohongshu_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_increase_fans` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_target`,
	ADD COLUMN `xiaohongshu_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_increase_fans`,
	ADD COLUMN `xiaohongshu_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees_target`,
	ADD COLUMN `xiaohongshu_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_increase_fans_fees`;


---直播前月目标添加抖音  线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `video_showcase_income_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_video_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_income_target`,
	ADD COLUMN `video_showcase_income_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_showcase_income`,
	ADD COLUMN `video_clues_target` INT NOT NULL DEFAULT 0 AFTER `video_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_video_clues` INT NOT NULL DEFAULT 0 AFTER `video_clues_target`,
	ADD COLUMN `video_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_clues`,
	ADD COLUMN `video_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `video_clues_complete_rate`,
	ADD COLUMN `cumulative_video_increase_fans` INT NOT NULL DEFAULT 0 AFTER `video_increase_fans_target`,
	ADD COLUMN `video_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_increase_fans`,
	ADD COLUMN `video_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_video_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees_target`,
	ADD COLUMN `video_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_increase_fans_fees`;


---直播前抖音日运营数据添加 线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_beforeliving_tiktok_daily_target`
	ADD COLUMN `tiktok_clues` INT NOT NULL DEFAULT 0 AFTER `tiktok_showcase_income`,
	ADD COLUMN `tiktok_increase_fans` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues`,
	ADD COLUMN `tiktok_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans`;


---直播前视频号日运营数据添加 线索,涨粉,涨粉费用,橱窗收入字段
ALTER TABLE `tbl_beforeliving_video_daily_target`
	ADD COLUMN `video_clues` INT NOT NULL DEFAULT 0 AFTER `send_num`,
	ADD COLUMN `video_increase_fans` INT NOT NULL DEFAULT 0 AFTER `video_clues`,
	ADD COLUMN `video_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans`,
	ADD COLUMN `video_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees`;


---直播前小红书日运营数据添加 线索,涨粉,涨粉费用,橱窗收入字段
ALTER TABLE `tbl_beforeliving_xiaohongshu_daily_target`
	ADD COLUMN `xiaohongshu_clues` INT NOT NULL DEFAULT 0 AFTER `record_date`,
	ADD COLUMN `xiaohongshu_increase_fans` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues`,
	ADD COLUMN `xiaohongshu_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans`,
	ADD COLUMN `xiaohongshu_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees`;

--直播月目标添加抖音,小红书,视频号 橱窗付费
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `tiktok_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_tiktok_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_showcase_fee_target`,
	ADD COLUMN `tiktok_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_showcase_fee`,
	ADD COLUMN `xiaohongshu_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_showcase_fee_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_fee_target`,
	ADD COLUMN `xiaohongshu_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_showcase_fee`,
	ADD COLUMN `video_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_fee_complete_rate`,
	ADD COLUMN `cumulative_video_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_fee_target`,
	ADD COLUMN `video_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_showcase_fee`;

--直播前抖音日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_tiktok_daily_target`
	ADD COLUMN `tiktok_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees`;

--直播前视频号日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_video_daily_target`
	ADD COLUMN `video_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_income`;

--直播前小红书日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_xiaohongshu_daily_target`
	ADD COLUMN `xiaohongshu_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income`;


	----------------------------------------王健  2024/1/25 END------------------------------------------


----------------------------------------王健  2024/3/20 BEGIN------------------------------------------

---回访记录添加回访截图
ALTER TABLE `tbl_track_record`
	ADD COLUMN `track_picture1` VARCHAR(300) NULL DEFAULT NULL AFTER `track_plan`,
	ADD COLUMN `track_picture2` VARCHAR(300) NULL DEFAULT NULL AFTER `track_picture1`,
	ADD COLUMN `track_picture3` VARCHAR(300) NULL DEFAULT NULL AFTER `track_picture2`;

----------------------------------------王健  2024/3/20 END------------------------------------------

----------------------------------------------余建明 2024/3/26 BEGIN----------------------------------------
--回访列表新增小黄车登记id
ALTER TABLE `amiyadb`.`tbl_track_record` 
ADD COLUMN `shpping_cart_registration_id` VARCHAR(30) NULL AFTER `track_picture3`;
----------------------------------------------余建明 2024/3/26 END----------------------------------------
----------------------------------------------余建明 2024/3/26 BEGIN----------------------------------------
--追踪回访记录表新增新老客回访区分
ALTER TABLE `amiyadb`.`tbl_track_record` 
ADD COLUMN `is_old_customer_track` BIT(1) NOT NULL DEFAULT 0 AFTER `shpping_cart_registration_id`;

--追踪回访记录表新增是否加v，未加v原因
ALTER TABLE `amiyadb`.`tbl_track_record` 
ADD COLUMN `is_add_wechat` BIT(1) NOT NULL DEFAULT 0 AFTER `is_old_customer_track`,
ADD COLUMN `un_add_wechat_reasonid` INT NOT NULL DEFAULT 0 AFTER `is_add_wechat`;

----------------------------------------------余建明 2024/3/26 END----------------------------------------

----------------------------------------------王健 2024/3/26 BEGIN----------------------------------------

---回访类型添加新老客
ALTER TABLE `tbl_track_type`
	ADD COLUMN `is_old_customer` BIT NOT NULL AFTER `has_model`;

----------------------------------------------王健 2024/3/26 END----------------------------------------


---------------------------------------------王健 2024/04/10 BEGIN----------------------------------------

----直播后月运营数据添加分诊数据维度
ALTER TABLE `tbl_liveanchor_monthly_target_after_living`
	ADD COLUMN `distribute_consulation_target` INT NOT NULL DEFAULT '0' AFTER `potential_performance_completeRate`,
	ADD COLUMN `cumulative_distribute_consulation` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `distribute_consulation_target`,
	ADD COLUMN `distribute_consulation_completeRate` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `cumulative_distribute_consulation`;

----直播后日运营数据添加分诊数据维度
ALTER TABLE `tbl_after_living_daily_target`
	ADD COLUMN `distribute_consulation` INT NOT NULL DEFAULT '0' AFTER `potential_performance`;


---------------------------------------------王健 2024/04/10 END----------------------------------------


---------------------------------------------王健 2024/04/22 BEGIN----------------------------------------

---助理个人业绩目标添加新客上门目标,老客上门目标
ALTER TABLE `tbl_employee_performance_target`
	ADD COLUMN `old_customer_visit_target` INT NOT NULL DEFAULT '0' AFTER `valid`,
	ADD COLUMN `new_customer_visit_target` INT NOT NULL DEFAULT '0' AFTER `old_customer_visit_target`;

---------------------------------------------王健 2024/04/22 END----------------------------------------


----------------------------------------------余建明 2024/5/14 BEGIN----------------------------------------
--粉丝见面会新增绑定基础主播id
ALTER TABLE `amiyadb`.`tbl_fans_meeting` 
ADD COLUMN `base_live_anchor_id` VARCHAR(50) NULL AFTER `hospital_id`;

----------------------------------------------余建明 2024/5/14 END----------------------------------------




------------------------------------王健 2024/5/14 BEGIN--------------------------------------

---粉丝见面会详情添加是否成交,到院,累计消费金额
ALTER TABLE `tbl_fans_meeting_details`
	ADD COLUMN `is_deal` BIT NOT NULL DEFAULT 0 AFTER `customer_picture_url`,
	ADD COLUMN `is_to_hospital` BIT NOT NULL DEFAULT 0 AFTER `is_deal`,
	ADD COLUMN `cumulative_deal_price` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `is_to_hospital`;




------------------------------------王健 2024/5/14 END--------------------------------------


------------------------------------王健 2024/5/17 BEGIN--------------------------------------

----小黄车数据添加归属渠道
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `belong_channel` INT NOT NULL DEFAULT 0 AFTER `customer_type`;

------------------------------------王健 2024/5/17 END--------------------------------------


------------------------------------王健 2024/6/12 BEGIN--------------------------------------

--录单申请添加截图
ALTER TABLE `tbl_content_pat_form_order_add_work`
	ADD COLUMN `picture` VARCHAR(300) NULL DEFAULT NULL AFTER `check_date`;


------------------------------------王健 2024/6/12 END--------------------------------------
----------------------------------------------余建明 2024/06/14 BEGIN----------------------------------------

ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `content_plat_form_order_addorderprice` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `customer_service_performance`;
----------------------------------------------余建明 2024/06/14 END----------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上
