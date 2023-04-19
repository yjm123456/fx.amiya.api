-----------------------------------------------余建明 2023/04/03 BEGIN--------------------------------------------
--对账单列表新增发票编号
ALTER TABLE `amiyadb`.`tbl_reconciliation_documents` 
ADD COLUMN `bill_id2` VARCHAR(50) NULL AFTER `create_by`;

-----------------------------------------------余建明 2023/04/03 END--------------------------------------------


-----------------------------------------------王健 2023/04/03 BEGIN--------------------------------------------

----客户表添加小程序app_id
ALTER TABLE `tbl_customer_info`
	ADD COLUMN `app_id` VARCHAR(50) NULL DEFAULT NULL AFTER `phone`;
-----------------------------------------------王健 2023/04/03 END--------------------------------------------

-----------------------------------------------余建明 2023/04/11 BEGIN--------------------------------------------
--内容平台订单列表新增医院网咨与医院现场咨询人员名称登记
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `network_consulation_name` VARCHAR(45) NULL AFTER `send_date`,
ADD COLUMN `scene_consulation_name` VARCHAR(45) NULL AFTER `network_consulation_name`;
-----------------------------------------------余建明 2023/04/11 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


-----------------------------------------------余建明 2023/04/13 BEGIN--------------------------------------------
--小黄车订单列表新增指派人
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `assign_emp_id` INT NULL AFTER `is_send_order`;
ADD COLUMN `sub_phone` VARCHAR(45) NULL AFTER `phone`;
--同步小黄车订单列表创建人为指派人
update  amiyadb.tbl_shopping_cart_registration set assign_emp_id=create_by
-----------------------------------------------余建明 2023/04/13 END--------------------------------------------

