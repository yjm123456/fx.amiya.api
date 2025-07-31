

------------------------------------余建明 2024/10/15 BEGIN--------------------------------------
--小黄车登记列表新增是否为历史顾客激活，激活人选项
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_history_customer_active` BIT(1) NOT NULL DEFAULT b'0' AFTER `is_ribuluo_living`,
ADD COLUMN `active_emp_id` INT NULL AFTER `is_history_customer_active`;

--小黄车登记列表新增来源词条和客户微信号
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `custoemr_wechat_no` VARCHAR(100) NULL AFTER `sub_phone`,
ADD COLUMN `from_title` VARCHAR(400) NULL AFTER `active_emp_id`;
------------------------------------余建明 2024/10/17 END--------------------------------------



------------------------------------王健 2024/10/17 BEGIN--------------------------------------

--直播前月度目标添加负责人
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `owner_id` INT NULL AFTER `video_showcase_fee_complete_rate`;

------------------------------------王健 2024/10/17 END--------------------------------------


------------------------------------余建明 2024/10/21 BEGIN--------------------------------------
--助理提取薪资模块新增提成金额
ALTER TABLE `amiyadb`.`tbl_customer_service_check_performance` 
ADD COLUMN `performance_commission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `delete_date`,
ADD COLUMN `performance_commission_check` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `performance_commission`;
------------------------------------余建明 2024/10/21 END--------------------------------------


------------------------------------余建明 2024/10/28 BEGIN--------------------------------------
--助理薪资数据加入版本号
ALTER TABLE `amiyadb`.`tbl_customer_service_compensation` 
ADD COLUMN `verison` VARCHAR(45) NULL AFTER `special_hospital_visit_price`;

--将当前助理薪资默认为1.0版本
update  amiyadb.tbl_customer_service_compensation set verison="1.0";
------------------------------------余建明 2024/10/28 END--------------------------------------

--小黄车列表新增是否重复下单（针对直播中面诊卡）
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_repeate_create_order` BIT(1) NOT NULL DEFAULT b'0' AFTER `from_title`;

--成交情况表加入上一条成交单id
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `last_deal_info_id` VARCHAR(50) NULL AFTER `consumption_type`;

--成交情况列表加入是否有效数据列
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `valid` BIT(1) NOT NULL AFTER `last_deal_info_id`;

update tbl_content_platform_order_deal_info set valid=true;


--粉丝见面会详情新增是否需助理跟进
ALTER TABLE `amiyadb`.`tbl_fans_meeting_details` 


--内容平台成交情况表新增补单时间，上一条成交创建时间
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `last_deal_info_create_date` DATETIME NULL AFTER `last_deal_info_id`,
ADD COLUMN `replenishment_create_date` DATETIME NULL AFTER `last_deal_info_create_date`;
ADD COLUMN `is_need_customerservice_help` BIT(1) NOT NULL AFTER `is_need_hospital_help`;

------------------------------------余建明 2025/01/09 BEGIN--------------------------------------
--小黄车登记列表新增归属公司
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `belong_company` INT NOT NULL DEFAULT 0 AFTER `is_repeate_create_order`;

--内容平台订单列表新增归属公司
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `order_belong_company` INT NOT NULL DEFAULT 0 AFTER `is_ribuluo_living`;

------------------------------------余建明 2025/01/09 END--------------------------------------

------------------------------------余建明 2025/03/08 BEGIN--------------------------------------
--主播基础信息新增是否为医生标识
ALTER TABLE `amiyadb`.`tbl_live_anchor_base_info` 
ADD COLUMN `is_doctor` BIT(1) NOT NULL AFTER `is_self_live_anchor`;
------------------------------------余建明 2025/03/08 END--------------------------------------

------------------------------------余建明 2025/03/19 BEGIN--------------------------------------
--新增医院类型（0：其他；1：直客；2：渠道）
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `hospital_type` INT NOT NULL DEFAULT 0 AFTER `security_deposit_money`;

update tbl_hospital_info set hospital_type=1;


--直播前月目标新增小红书的私信开口量和名片发送量
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target_before_living` 
ADD COLUMN `xiaohongshu_private_message_open_target` INT NOT NULL DEFAULT 0.00 AFTER `owner_id`,
ADD COLUMN `cumulative_xiaohongshu_private_message_open` INT NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_private_message_open_target`,
ADD COLUMN `xiaohongshu_private_message_open_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_xiaohongshu_private_message_open`,
ADD COLUMN `xiaohongshu_calling_card_sendnum_target` INT NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_private_message_open_complete_rate`,
ADD COLUMN `cumulative_xiaohongshu_calling_card_sendnum` INT NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_calling_card_sendnum_target`,
ADD COLUMN `xiaohongshu_calling_card_sendnum_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_xiaohongshu_calling_card_sendnum`;

--直播前小红书日数据新增私信开口量和名片发送量数据
ALTER TABLE `amiyadb`.`tbl_beforeliving_xiaohongshu_daily_target` 
ADD COLUMN `xiaohongshu_private_message_open` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_showcase_fee`,
ADD COLUMN `xiaohongshu_calling_card_sendnum` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_private_message_open`;


--小黄车登记列表新增关联人
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `affiliated_person` INT NULL AFTER `belong_company`;

--订单列表新增预约时段，是否为医生订单，指派（医生）咨询师id
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `appointment_detail_date` VARCHAR(45) NULL AFTER `appointment_date`,
ADD COLUMN `is_doctor_order` BIT(1) NOT NULL DEFAULT b'0' AFTER `order_belong_company`,
ADD COLUMN `consult_emp_id` INT NULL AFTER `is_doctor_order`;


------------------------------------余建明 2025/03/24 END--------------------------------------

------------------------------------余建明 2025/04/11 BEGIN--------------------------------------
--客户基础信息加入省份列
ALTER TABLE `amiyadb`.`tbl_customer_base_info` 
ADD COLUMN `province` VARCHAR(45) NULL AFTER `wechat_number`;
------------------------------------余建明 2025/04/11 END--------------------------------------



------------------------------------余建明 2025/05/16 BEGIN--------------------------------------
--微博数据加入备注
ALTER TABLE `amiyadb`.`tbl_beforeliving_sina_weibo_daily_target` 
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `record_date`;

--抖音直播前日运营数据加入备注
ALTER TABLE `amiyadb`.`tbl_beforeliving_tiktok_daily_target` 
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `tiktok_showcase_fee`;

--视频号直播前日运营数据加入备注
ALTER TABLE `amiyadb`.`tbl_beforeliving_video_daily_target` 
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `video_showcase_fee`;

--小红书直播前日运营数据加入备注
ALTER TABLE `amiyadb`.`tbl_beforeliving_xiaohongshu_daily_target` 
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `xiaohongshu_calling_card_sendnum`;
------------------------------------余建明 2025/05/16 END--------------------------------------

------------------------------------余建明 2025/07/31 BEGIN--------------------------------------
--医院列表加入备注功能
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `hospital_type`;
------------------------------------余建明 2025/07/31 END--------------------------------------
--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------
