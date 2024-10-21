﻿

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

--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------

------------------------------------余建明 2024/10/21 BEGIN--------------------------------------
--助理提取薪资模块新增提成金额
ALTER TABLE `amiyadb`.`tbl_customer_service_check_performance` 
ADD COLUMN `performance_commission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `delete_date`;
ADD COLUMN `performance_commission_check` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `performance_commission`;
------------------------------------余建明 2024/10/21 END--------------------------------------
