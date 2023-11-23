


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
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上

------------------------------------------------ 王健 2023/11/21 BEGIN ------------------------------------------------------


----内容平台派单添加主派.次派
ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `is_main_hospital` BIT(1) NOT NULL DEFAULT 0 AFTER `hospital_remark`;

update tbl_content_platform_order_send set is_main_hospital=true;


-------------------------------------------- 王健 2023/11/21 END-------------------------------------------------


