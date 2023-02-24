﻿-----------------------------------------------余建明 2021/06/18 BEGIN------------------------------------------
ALTER TABLE tbl_order_info ADD COLUMN Description VARCHAR(200) DEFAULT NULL COMMENT '简介' AFTER trade_id;
ALTER TABLE tbl_order_info ADD COLUMN Standard VARCHAR(100) DEFAULT NULL COMMENT '规格' AFTER Description;
ALTER TABLE tbl_order_info ADD COLUMN Parts VARCHAR(100) DEFAULT NULL COMMENT '部位' AFTER Standard;
-----------------------------------------------余建明 2021/06/18 END--------------------------------------------

-----------------------------------------------余建明 2021/07/07 BEGIN------------------------------------------
ALTER TABLE tbl_hospital_info ADD COLUMN `business_hours` VARCHAR(50)  DEFAULT NULL COMMENT '营业时间' AFTER `city_id`;

ALTER TABLE tbl_goods_info
ADD COLUMN `details_description` VARCHAR(500)  NULL AFTER `version`,
ADD COLUMN `max_show_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT '0.00' AFTER `details_description`,
ADD COLUMN `min_show_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT '0.00' AFTER `max_show_price`,
ADD COLUMN `visit_count` INT UNSIGNED NULL DEFAULT 0 AFTER `min_show_price`,
ADD COLUMN `sale_count` INT UNSIGNED NULL DEFAULT 0 AFTER `visit_count`,
ADD COLUMN `show_sale_count` INT UNSIGNED NULL DEFAULT 0 AFTER `sale_count`;

-----------------------------------------------余建明 2021/07/07 END--------------------------------------------



-----------------------------------------------余建明 2021/07/17 BEGIN------------------------------------------
ALTER TABLE `amiyadb`.`tbl_goods_category` 
ADD COLUMN `show_direction_type` INT NOT NULL DEFAULT 0 AFTER `update_date`;
-----------------------------------------------余建明 2021/07/17 END--------------------------------------------


-----------------------------------------------余建明 2021/07/28 BEGIN------------------------------------------

--tbl_config表修改config列【加入微分销渠道】
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{\"FxJwtConfig\":{\"Key\":\"kljdsf982734jkldg!@#\",\"ExpireInSeconds\":7200,\"RefreshTokenExpireInSeconds\":14400},\"FxOpenConfig\":{\"Enable\":true,\"RequestBaseUrl\":\"https://app.hsltm.com/fxgatetest\"},\"FxOSSConfig\":null,\"FxRedisConfig\":{\"ConnectionString\":\"app.hsltm.com:6379,allowadmin=true,password=hsltm\"},\"FxSmsConfig\":{\"AliyunSmsList\":[{\"Name\":\"send_validate_code\",\"AccessKeyId\":\"LTAIlyCdQbQnA96C\",\"AccessSecret\":\"nXtBYoUzt3nw3v5DasAjNdLliuBB0h\",\"RegionId\":\"cn_hangzhou\",\"SignName\":\"杭州华山医院\",\"TemplateCode\":\"SMS_126464576\",\"Remark\":\"发送验证码\"}]},\"FxUniteWxAccessTokenConfig\":{\"Enable\":true,\"RequestBaseUrl\":\"https://app.hsltm.com/fxwxaccesstoken\"},\"WxPayConfig\":null,\"FxMessageCenterConfig\":{\"EnableMessageCenter\":true,\"EnableMessageQueue\":true,\"MQHostName\":\"app.hsltm.com\",\"MQUserName\":\"admin\",\"Port\":5672,\"MQPassword\":\"hsltm1007\",\"MQQueueName\":\"fx_wxmp_message_queue\",\"MessageCenterWebSocketUrl\":null},\"ChatInMinute\":1440,\"CallCenterConfig\":{\"CallRecordStoreAddress\":\"mongodb://192.168.11.72:27890\",\"EnablevoiceCardCallable\":false,\"SupportOldCallBox\":false,\"SwitchSimCardInCallCount\":5,\"VoiceCardManagerAddress\":\"\",\"PhoneEncryptKey\":\"test\",\"EnablePhoneEncrypt\":true,\"HidePhoneNumber\":true},\"SyncOrderConfig\":{\"Jd\":false,\"Tmall\":true,\"WeiFenXiao\":true}}' WHERE (`id` = '1');

--tbl_order_app_info表加入微分销商户号配置
insert into amiyadb.tbl_order_app_info Values('4','4003356','a3ac5675bd09247fb89c13f60101a286','4032396','2021-07-28 11:20:22','3','2021-07-28 11:20:22',' ')

-----------------------------------------------余建明 2021/07/28 END--------------------------------------------



-----------------------------------------------余建明 2021/08/04 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_goods_category` 
ADD COLUMN `sort` INT NULL DEFAULT 0 AFTER `show_direction_type`;
-----------------------------------------------余建明 2021/08/04 END--------------------------------------------


-----------------------------------------------余建明 2021/08/10 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `write_off_code` VARCHAR(50) NULL DEFAULT NULL AFTER `Parts`,
ADD COLUMN `already_write_off_amount` INT NOT NULL DEFAULT 0 AFTER `write_off_code`;
insert into amiyadb.tbl_module Values('45','wirteoOff','订单核销',1,'/orderWriteOff','8')


--fxSmsconfig更改：AliyunSmsList加入新集合数据
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_222467940","Remark":"订单下单通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_222473088","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false}}' WHERE (`id` = '1');
-----------------------------------------------余建明 2021/08/10 END--------------------------------------------


-----------------------------------------------余建明 2021/08/31 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `write_off_date` DATETIME NULL DEFAULT NULL AFTER `update_date`;
-----------------------------------------------余建明 2021/08/31 END--------------------------------------------


--------------【1.2版本更新分支数据库更改】


-----------------------------------------------余建明 2021/09/04 BEGIN--------------------------------------------

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('46', 'expressManage', '物流公司', 1, '/expressManage', 12);

ALTER TABLE `amiyadb`.`tbl_send_goods_record` 
ADD COLUMN `express_id` VARCHAR(50) NULL AFTER `courier_number`;

ALTER TABLE `amiyadb`.`tbl_receive_gift` 
ADD COLUMN `express_id` VARCHAR(50) NULL AFTER `address_id`;


-----------------------------------------------余建明 2021/09/04 END--------------------------------------------

-----------------------------------------------余建明 2021/09/07 BEGIN--------------------------------------------


ALTER TABLE `amiyadb`.`tbl_order_trade` 
ADD COLUMN `is_admin_add` BIT(1) NOT NULL AFTER `update_date`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (47, 'hospitalDepartment', '医院科室', 1, '/hospitalDepartment', 12);
INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (48, 'goodsDemand', '需求项目列表', 1, '/goodsDemand', 12);

ALTER TABLE `amiyadb`.`tbl_amiya_goods_demand` 
ADD COLUMN `thumb_picturl_url` VARCHAR(200) NULL AFTER `description`;


-----------------------------------------------余建明 2021/09/07 END--------------------------------------------


--------------【feature-预约到店升级】

-----------------------------------------------余建明 2021/09/10 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_appointment_info` 
DROP FOREIGN KEY `fk_appointmentinfo_orderid_order_id`;
ALTER TABLE `amiyadb`.`tbl_appointment_info` 
DROP COLUMN `order_id`,
CHANGE COLUMN `item_info_id` `item_info_name` VARCHAR(200) NULL AFTER `submit_date`,
DROP INDEX `fk_appointmentinfo_orderid_order_id` ;

ALTER TABLE `amiyadb`.`tbl_appointment_info` 
ADD COLUMN `customer_name` VARCHAR(200) NULL AFTER `customer_id`;

---------------------------------  9/14新增
ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `e_mail` VARCHAR(100) NOT NULL DEFAULT 0 AFTER `is_customer_service`;


--------------------------------9/15新增

ALTER TABLE `amiyadb`.`tbl_amiya_hospital_department` 
ADD COLUMN `sort` INT NULL DEFAULT NULL AFTER `description`;

UPDATE amiyadb.tbl_amiya_hospital_department SET SORT=1

ALTER TABLE `amiyadb`.`tbl_amiya_hospital_department` 
CHANGE COLUMN `sort` `sort` INT NOT NULL DEFAULT '0' ;


--新增阿里云sms积分兑换通知
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224341042","Remark":"订单下单通知"},{"Name":"order_intergrationpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224351049","Remark":"积分兑换通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224346105","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false}}' WHERE (`id` = '1');


--------------------------------9/22

ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
ADD COLUMN `is_hot` BIT(1) NOT NULL AFTER `valid`;


ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
ADD COLUMN `province_id` VARCHAR(50) NOT NULL DEFAULT '0' AFTER `is_hot`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (49, 'ProvinceManage', '省份管理', 1, '/province', 12);



--------------------------------9/23

INSERT INTO `amiyadb`.`tbl_module_category` (`id`, `name`, `description`, `valid`, `path`) VALUES ('17', 'beautyDiary', '美丽日记', 1, '/beautyDiary');

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('50', 'BeautyDiaryManage', '日记管理', 1, '/beautyDiaryManage', '17');
INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('51', 'BeautyDiaryTagInfo', '日记标签', 1, '/beautyDiaryTagInfo', '17');

-----------------------------------------------余建明 2021/09/23 END--------------------------------------------;

-----------------------------------------------余建明 2021/10/13 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `order_nature` TINYINT NOT NULL DEFAULT 0 AFTER `order_type`;

ALTER TABLE `amiyadb`.`tbl_module` 
ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `module_category_id`;

ALTER TABLE `amiyadb`.`tbl_module_category` 
ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `path`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`, `sort`) VALUES (52, 'MenuManage', '菜单管理', 1, '/MenuManage', 12, 0);

-----------------------------------------------余建明 2021/10/13 END--------------------------------------------;



-----------------------------------------------余建明 2021/11/02 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `account_receivable` DECIMAL(10,2) NULL DEFAULT NULL AFTER `actual_payment`,--应收款

ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `final_consumption_hospital` VARCHAR(100) NULL DEFAULT NULL AFTER `appointment_hospital`;


update tbl_order_info set final_consumption_hospital=appointment_hospital, account_receivable=actual_payment

-----------------------------------------------余建明 2021/11/02 END--------------------------------------------;


-----------------------------------------------余建明 2021/11/08 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `added_by` INT NULL DEFAULT '0' AFTER `consume_type`;
-----------------------------------------------余建明 2021/11/08 END--------------------------------------------;







-----------------------------------------------余建明 2021/11/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_live_anchor` 
ADD COLUMN `host_account_name` VARCHAR(45) NULL AFTER `name`,
ADD COLUMN `content_plateform_id` VARCHAR(50) NULL AFTER `host_account_name`;



-----------------------------------------------余建明 2021/11/10 END--------------------------------------------;


-----------------------------------------------余建明 2021/11/11 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
CHANGE COLUMN `appointment_hospital_id` `appointment_hospital_id` INT NULL DEFAULT NULL ;

ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
ADD COLUMN `goods_id` VARCHAR(50) NULL AFTER `update_date`,
-----------------------------------------------余建明 2021/11/11 END--------------------------------------------;




-----------------------------------------------侯宝平 2021/11/11 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
MODIFY COLUMN `live_anchor_id` int(11) UNSIGNED NULL DEFAULT NULL AFTER `content_plateform_id`,
MODIFY COLUMN `appointment_hospital_id` int(11) UNSIGNED NULL DEFAULT NULL AFTER `appointment_date`,
ADD CONSTRAINT `fk_contentPlatformOrder_contentPlateformId_ContentPlateform_id` FOREIGN KEY (`content_plateform_id`) REFERENCES `amiyadb`.`tbl_content_platform` (`id`),
ADD CONSTRAINT `fk_contentPlatformOrder_liveAnchorId_liveAnchor_id` FOREIGN KEY (`live_anchor_id`) REFERENCES `amiyadb`.`tbl_live_anchor` (`id`),
ADD CONSTRAINT `fk_contentPlatformOrder_appointmentHospitalId_hospitalInfoId_id` FOREIGN KEY (`appointment_hospital_id`) REFERENCES `amiyadb`.`tbl_hospital_info` (`id`);

ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
ADD CONSTRAINT `fk_contentPlatformOrder_goodsId_amiyaGoodsDemand_id` FOREIGN KEY (`goods_id`) REFERENCES `amiyadb`.`tbl_amiya_goods_demand` (`id`);

-----------------------------------------------侯宝平 2021/11/11 END--------------------------------------------;


-----------------------------------------------侯宝平 2021/11/12 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_check_phone_record` DROP FOREIGN KEY `fk_hospitalCheckPhoneRecord_orderid_order_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_check_phone_record` 
ADD COLUMN `order_platformn_type` tinyint(4) NOT NULL COMMENT '0=正常交易订单（淘宝等平台），1=内容平台订单' AFTER `hospital_employee_id`;
-----------------------------------------------侯宝平 2021/11/12 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/1 BEGIN--------------------------------------------;
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224341042","Remark":"订单下单通知"},{"Name":"order_intergrationpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224351049","Remark":"积分兑换通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"啊美雅","TemplateCode":"SMS_224346105","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false},"NoticeConfig":{"EmailNoticeConfig":true}}' WHERE (`id` = '1');


ALTER TABLE `amiyadb`.`tbl_send_order_info` 
ADD COLUMN `purchase_single_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `send_date`,
ADD COLUMN `purchase_num` INT NOT NULL DEFAULT 0 AFTER `purchase_single_price`;


ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `live_anchor_id` INT NOT NULL DEFAULT '0' AFTER `already_write_off_amount`;


-----------------------------------------------余建明 2021/12/3 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/13 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `nick_name` VARCHAR(45) NULL AFTER `added_by`,
ADD COLUMN `is_added_order` BIT(1) NOT NULL DEFAULT 0 AFTER `nick_name`,
ADD COLUMN `order_id` VARCHAR(50) NULL AFTER `is_added_order`,
ADD COLUMN `write_off_date` DATETIME NULL AFTER `order_id`,
ADD COLUMN `is_consultation_card` BIT(1) NOT NULL DEFAULT 0 AFTER `write_off_date`,
ADD COLUMN `buy_again_type` INT NOT NULL DEFAULT 0 AFTER `is_consultation_card`,
ADD COLUMN `is_self_living` BIT(1) NOT NULL DEFAULT 0 AFTER `buy_again_type`,
ADD COLUMN `buy_again_time` DATETIME NULL AFTER `is_self_living`,
ADD COLUMN `has_buyagain_evidence` BIT(1) NOT NULL DEFAULT 0 AFTER `buy_again_time`,
ADD COLUMN `buyagain_evidence_pic` VARCHAR(200) NULL AFTER `has_buyagain_evidence`,
ADD COLUMN `is_checktohospital` BIT(1) NOT NULL DEFAULT 0 AFTER `buyagain_evidence_pic`,
ADD COLUMN `checktohospital_pic` VARCHAR(200) NULL AFTER `is_checktohospital`,
ADD COLUMN `person_time` INT NOT NULL DEFAULT 1 AFTER `checktohospital_pic`,
ADD COLUMN `is_receive_additional_purchase` BIT(1) NOT NULL DEFAULT 0 AFTER `person_time`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
CHANGE COLUMN `nick_name` `nick_name` VARCHAR(45) NULL ,
CHANGE COLUMN `order_id` `order_id` VARCHAR(50) NULL ,
CHANGE COLUMN `buyagain_evidence_pic` `buyagain_evidence_pic` VARCHAR(200) NULL ,
CHANGE COLUMN `checktohospital_pic` `checktohospital_pic` VARCHAR(200) NULL ;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `hospital_remark` VARCHAR(200) NULL AFTER `remark`;


-----------------------------------------------余建明 2021/12/18 END--------------------------------------------;

-----------------------------------------------余建明 2021/12/24 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `un_deal_picture_url` VARCHAR(200) NULL AFTER `undeal_reason`;
-----------------------------------------------余建明 2021/12/24 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/28 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_to_hospital` BIT(1) NOT NULL DEFAULT 0 AFTER `remark`;


-----------------------------------------------余建明 2021/12/28 END--------------------------------------------;

