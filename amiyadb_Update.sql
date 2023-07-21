﻿



-----------------------------------------------王健 2023/07/03 BEGIN--------------------------------------------

-----微信支付信息字段长度修改
ALTER TABLE `tbl_wechat_payinfo`
	CHANGE COLUMN `sub_app_id` `sub_app_id` VARCHAR(5000) NOT NULL AFTER `enablesp`,
	CHANGE COLUMN `sub_mch_id` `sub_mch_id` VARCHAR(5000) NOT NULL AFTER `sub_app_id`;

-----------------------------------------------王健 2023/07/03 BEGIN--------------------------------------------

-----------------------------------------------余建明 2023/07/07 END--------------------------------------------
--小黄车登记列表新增带货板块产品类型
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `product_type` INT NOT NULL DEFAULT 0 AFTER `source`;
-----------------------------------------------余建明 2023/07/07 END--------------------------------------------

--绑定客服列表新增RFM类型
ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `rfm_type` INT NOT NULL DEFAULT 0 AFTER `consumption_date`;
-----------------------------------------------余建明 2023/07/11 END--------------------------------------------


------------------------------------------------王健 2023/07/13 BEGIN--------------------------------------------

----修改支付信息表字段
ALTER TABLE `tbl_wechat_payinfo`
	CHANGE COLUMN `sub_app_id` `sub_app_id` VARCHAR(50) NOT NULL  AFTER `enablesp`,
	CHANGE COLUMN `sub_mch_id` `sub_mch_id` VARCHAR(50) NOT NULL  AFTER `sub_app_id`,
	ADD COLUMN `private_key` VARCHAR(5000) NOT NULL AFTER `sub_mch_id`,
	ADD COLUMN `public_key` VARCHAR(5000) NOT NULL AFTER `private_key`,
	ADD COLUMN `store_id` VARCHAR(50) NOT NULL AFTER `public_key`;

----添加证书名称字段
ALTER TABLE `tbl_wechat_payinfo`
	ADD COLUMN `certificate_name` VARCHAR(500) NULL DEFAULT NULL AFTER `delete_date`;


-------------------------------------------------王健 2023/07/13 END-------------------------------------------------


-----------------------------------------------余建明 2023/07/17 BEGIN--------------------------------------------
--小黄车登记列表新增获客方式
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `get_customer_type` INT NOT NULL DEFAULT 0 AFTER `product_type`;

--库存板块新增货架id
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD COLUMN `storage_racks_id` VARCHAR(50) NULL AFTER `total_price`;

--货架管理主外键更改
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
DROP FOREIGN KEY `fk_tbl_warehouse_storage_racks_warehouseinfo`;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
ADD INDEX `fk_tbl_warehouse_storage_racks_warehouseinfo_idx` (`warehouse_id` ASC) VISIBLE,
DROP INDEX `fk_tbl_warehouse_storage_racks_warehouseinfo_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
ADD CONSTRAINT `fk_tbl_warehouse_storage_racks_warehouseinfo`
  FOREIGN KEY (`warehouse_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse_name_manage` (`id`);

-----------------------------------------------余建明 2023/07/17 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


-----------------------------------------------余建明 2023/07/20 BEGIN--------------------------------------------
--升单加入审核助理服务费
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2)  NULL   AFTER `check_settle_price`;
-----------------------------------------------余建明 2023/07/20 END--------------------------------------------
