﻿

------------------------------------余建明 2024/9/3 BEGIN--------------------------------------
--三方平台添加访问地址和签名
ALTER TABLE `amiyadb`.`tbl_third_part_contentplatform_info` 
ADD COLUMN `api_url` VARCHAR(300) NULL AFTER `delete_date`,
ADD COLUMN `sign` VARCHAR(100) NULL AFTER `api_url`;

--派单列表新增是否指定医院账户和医院账户id
ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `is_specify_hospital_employee` BIT(1) NOT NULL DEFAULT 0 AFTER `is_repeat_profundity_order`,
ADD COLUMN `hospital_emp_id` INT NOT NULL DEFAULT 0 AFTER `is_specify_hospital_employee`;


------------------------------------余建明 2024/9/5 END--------------------------------------
------------------------------------王健 2024/9/2 BEGIN--------------------------------------

----小黄车登记添加加v截图和线索截图
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `add_wechat_picture` VARCHAR(100) NULL DEFAULT NULL AFTER `belong_channel`,
	ADD COLUMN `clue_picture` VARCHAR(100) NULL DEFAULT NULL AFTER `add_wechat_picture`;
---添加加v人
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `add_wechat_empid` INT NULL DEFAULT NULL AFTER `clue_picture`;


------------------------------------王健 2024/9/2 END--------------------------------------

------------------------------------余建明 2024/9/11 BEGIN--------------------------------------
--小黄车登记列表新增“是否为日不落直播”
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_ribuluo_living` BIT(1) NOT NULL DEFAULT 0 AFTER `add_wechat_empid`;

update amiyadb.tbl_shopping_cart_registration set is_ribuluo_living=true where source=11;

--订单列表新增“是否为日不落直播”
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_ribuluo_living` BIT(1) NOT NULL DEFAULT 0 AFTER `consulting_content2`;

update amiyadb.tbl_content_platform_order set is_ribuluo_living=true where customer_source=11;
------------------------------------余建明 2024/9/11 END--------------------------------------


------------------------------------王健 2024/9/25 BEGIN--------------------------------------

--助理薪资单添加特定医院上门奖励
ALTER TABLE `tbl_customer_service_compensation`
	ADD COLUMN `special_hospital_visit_price` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `old_take_newcustomer_price`;

------------------------------------王健 2024/9/25 END--------------------------------------
--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------

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