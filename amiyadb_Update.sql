


--------------------------------------------王健 2023/11/06 START-------------------------------------------------
--已领取礼物列表添加创建人,客户id可为空
ALTER TABLE `tbl_receive_gift`
	CHANGE COLUMN `customer_id` `customer_id` VARCHAR(50) NULL DEFAULT NULL AFTER `gift_id`,
	ADD COLUMN `create_by` INT NULL DEFAULT NULL AFTER `customer_id`;


--礼物发放类型
ALTER TABLE `tbl_receive_gift`
	ADD COLUMN `send_type` INT NOT NULL DEFAULT 0 AFTER `express_id`;

--------------------------------------------王健 2023/11/06 END-------------------------------------------------
-----------------------------------------------余建明 2023/11/06 BEGIN--------------------------------------------
--绑定客服列表新增累计赠送礼品次数
ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `system_send_gift_time` INT NULL AFTER `rfm_type`,
ADD COLUMN `new_system_send_gift_date` DATETIME NULL AFTER `system_send_gift_time`;

--下单平台派单列表新增是否为主派医院，并将现所有主派医院改为“是”
ALTER TABLE `amiyadb`.`tbl_send_order_info` 
ADD COLUMN `is_main_hospital` BIT(1) NOT NULL DEFAULT 0 AFTER `feedback_date`;

update tbl_send_order_info set is_main_hospital=true

-----------------------------------------------余建明 2023/11/07 END--------------------------------------------

------------------------------------------------ 王健 2023/11/21 BEGIN ------------------------------------------------------


----内容平台派单添加主派.次派
ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `is_main_hospital` BIT(1) NOT NULL DEFAULT 0 AFTER `hospital_remark`;

update tbl_content_platform_order_send set is_main_hospital=true;


-------------------------------------------- 王健 2023/11/21 END-------------------------------------------------



-------------------------------------------王健 2023/11/29  BEGIN ------------------------------------------------------


--抖音直播前日运营数据添加抖音橱窗收入
ALTER TABLE `tbl_beforeliving_tiktok_daily_target`
	CHANGE COLUMN `record_date` `record_date` DATETIME NOT NULL AFTER `valid`,
	ADD COLUMN `tiktok_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `send_num`;
	
	
--抖音直播前日运营数据添加抖音橱窗收入
ALTER TABLE `tbl_liveanchor_daily_target`
	ADD COLUMN `tiktok_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `living_update_date`;


--直播前月目标数据添加抖音橱窗收入,累计橱窗收入,橱窗收入目标完成率
	
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `tik_tok_showcase_income_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `flow_investment_complete_rate`,
	ADD COLUMN `cumulative_tik_tok_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `tik_tok_showcase_income_target`,
	ADD COLUMN `tik_tok_showcase_income_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_tik_tok_showcase_income`;

--------------------------------------------王健 2023/11/29 END----------------------------------------------------------

-----------------------------------------------余建明 2023/11/29 BEGIN--------------------------------------------
--小黄车登记列表新增顾客类型
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `customer_type` INT NOT NULL DEFAULT 0 AFTER `get_customer_type`;
-----------------------------------------------余建明 2023/11/29 END--------------------------------------------




------------------------------------------------王健 2023/12/6 BEGIN--------------------------------------------

--直播中添加投流细分数据
ALTER TABLE `tbl_living_daily_target`
	ADD COLUMN `tiktok_plus_num` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `refund_gmv`,
	ADD COLUMN `qian_chuan_num` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_plus_num`,
	ADD COLUMN `shui_xin_tui_num` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `qian_chuan_num`,
	ADD COLUMN `weixin_dou` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `shui_xin_tui_num`;


------------------------------------------------王健 2023/12/6 END--------------------------------------------



------------------------------------------------余建明 2023/12/6 BEGIN--------------------------------------------
--内容平台订单新增客户来源，获客类型
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `customer_source` INT NOT NULL DEFAULT 0 AFTER `get_customer_type`,
ADD COLUMN `customer_type` INT NOT NULL DEFAULT 0 AFTER `customer_source`;
------------------------------------------------余建明 2023/12/6 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


----------------------------------------------王健 2023/1/4 BEGIN----------------------------------------

ALTER TABLE `tbl_amiya_employee`
	ADD COLUMN `new_customer_commission` DECIMAL(10,2) NULL DEFAULT NULL AFTER `bind_base_live_anchor_id`,
	ADD COLUMN `old_customer_commission` DECIMAL(10,2) NULL DEFAULT NULL AFTER `new_customer_commission`,
	ADD COLUMN `inspection_commission` DECIMAL(10,2) NULL DEFAULT NULL AFTER `old_customer_commission`;


----------------------------------------------王健 2023/1/4 END----------------------------------------
 
----------------------------------------------余建明 2024/1/4 BEGIN----------------------------------------
--助理薪资审核新增提成点数与提成业绩
 ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `performance_percent` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `customer_service_compensation_id`,
ADD COLUMN `customer_service_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `performance_percent`;
----------------------------------------------余建明 2024/1/4 END----------------------------------------
