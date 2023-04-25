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


-----------------------------------------------余建明 2023/04/13 BEGIN--------------------------------------------
--小黄车订单列表新增指派人
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `assign_emp_id` INT NULL AFTER `is_send_order`;
ADD COLUMN `sub_phone` VARCHAR(45) NULL AFTER `phone`;
--同步小黄车订单列表创建人为指派人
update  amiyadb.tbl_shopping_cart_registration set assign_emp_id=create_by
-----------------------------------------------余建明 2023/04/13 END--------------------------------------------

-----------------------------------------------王健 2023/04/20 BEGIN--------------------------------------------

--轮播图添加归属小程序

ALTER TABLE `tbl_homepage_carousel_image`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `link_url`;


--商品添加归属小程序
ALTER TABLE `tbl_goods_info`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `sort`;


--商品添加是否热门
ALTER TABLE `tbl_goods_info`
	ADD COLUMN `ishot` BIT NOT NULL AFTER `appid`;

--商品分类添加归属小程序和是否热门
ALTER TABLE `tbl_goods_category`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `category_img`,
	ADD COLUMN `ishot` BIT NOT NULL AFTER `appid`;

---客户信息添加跳转appid
ALTER TABLE `tbl_customer_info`
	ADD COLUMN `assiste_app_id` VARCHAR(50) NULL DEFAULT NULL AFTER `app_id`;

----预约添加叫车地址
ALTER TABLE `tbl_appointment_info`
	ADD COLUMN `address` VARCHAR(500) NULL DEFAULT NULL AFTER `appoint_area`;



---商品分类添加是否是品牌分类
ALTER TABLE `tbl_goods_category`
	ADD COLUMN `isbrand` BIT NOT NULL AFTER `ishot`;

-----------------------------------------------王健 2023/04/20 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上




-------------------------------------------------王健 2023/04/25 BEGIN---------------------------------------------


-----预约日程添加预约医院和接诊咨询
ALTER TABLE `tbl_customer_appointment_schedule`
	ADD COLUMN `appointment_hospital_id` INT NULL DEFAULT NULL AFTER `remark`,
	ADD COLUMN `consultation` VARCHAR(50) NULL DEFAULT NULL AFTER `appointment_hospital_id`;


-------------------------------------------------王健 2023/04/25 END---------------------------------------------
