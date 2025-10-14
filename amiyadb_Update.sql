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


------------------------------------余建明 2025/08/22 BEGIN--------------------------------------
--员工管理新增地区（默认为“0”中国区）
ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `area` INT NOT NULL DEFAULT 0 AFTER `administrative_inspection`;


--平台列表新增英文名
ALTER TABLE `amiyadb`.`tbl_content_platform` 
ADD COLUMN `content_platform_english_name` VARCHAR(45) NULL AFTER `content_platform_name`;

--内容平台订单列表新增地区属性（根据登陆账户进行确定）
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `area` INT NOT NULL DEFAULT 0 AFTER `consult_emp_id`;

--客户基础信息新增地区属性
ALTER TABLE `amiyadb`.`tbl_customer_base_info` 
ADD COLUMN `area` INT NULL DEFAULT 0 AFTER `remark`;

--小黄车列表新增地区属性
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `area` INT NOT NULL DEFAULT 0 AFTER `affiliated_person`;

--医院新增地区属性
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `hospital_area` INT NOT NULL DEFAULT 0 AFTER `remark`;

--省份，城市字段扩大内容并加入胡志明市
ALTER TABLE `amiyadb`.`tbl_province` 
CHANGE COLUMN `name` `name` VARCHAR(500) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL ;
INSERT INTO `amiyadb`.`tbl_province` (`id`, `name`, `valid`) VALUES ('a9d70561-fcb3-465a-82b1-f6776e92358s', 'Thành phố Hồ Chí Minh', true);
ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
CHANGE COLUMN `name` `name` VARCHAR(500) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL ;
INSERT INTO `amiyadb`.`tbl_cooperative_hospital_city` (`name`, `valid`, `is_hot`, `province_id`, `sort`) VALUES ('Thành phố Hồ Chí Minh', true, true, 'a9d70561-fcb3-465a-82b1-f6776e92358s', 0);

--客户基础信息列表的省份与城市与性别扩容
ALTER TABLE `amiyadb`.`tbl_customer_base_info` 
CHANGE COLUMN `province` `province` VARCHAR(500) NULL DEFAULT NULL ,
CHANGE COLUMN `city` `city` VARCHAR(500) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL ;
ALTER TABLE `amiyadb`.`tbl_customer_base_info` 
CHANGE COLUMN `sex` `sex` CHAR(20) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL ;



------------------------------------余建明 2025/08/22 END--------------------------------------
------------------------------------余建明 2025/08/29 BEGIN--------------------------------------
--派单列表新增地区属性
ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `area` INT NOT NULL DEFAULT 0 AFTER `hospital_emp_id`;


------------------------------------余建明 2025/08/29 END--------------------------------------


------------------------------------余建明 2025/09/23 BEGIN--------------------------------------
--职位列表新增描述
ALTER TABLE `amiyadb`.`tbl_amiya_position_info` 
ADD COLUMN `description` VARCHAR(70) NULL AFTER `name`;

--回访目的管理新增描述
ALTER TABLE `amiyadb`.`tbl_track_type` 
ADD COLUMN `description` VARCHAR(150) NULL DEFAULT  AFTER `is_old_customer`;

--客户类型管理新增描述
ALTER TABLE `amiyadb`.`tbl_track_theme` 
ADD COLUMN `description` VARCHAR(150) NULL AFTER `valid`;

--回访工具新增描述
ALTER TABLE `amiyadb`.`tbl_track_tool` 
ADD COLUMN `description` VARCHAR(150) NULL AFTER `valid`;

--医院账户新增地区属性
ALTER TABLE `amiyadb`.`tbl_hospital_employee` 
ADD COLUMN `area` INT NOT NULL DEFAULT 0 AFTER `is_customer_service`;



------------------------------------余建明 2025/09/23 END--------------------------------------

--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------


------------------------------------余建明 2025/10/11 BEGIN--------------------------------------
--医院标签新增描述
ALTER TABLE `amiyadb`.`tbl_tag_info` 
ADD COLUMN `description` VARCHAR(100) NULL AFTER `name`;
UPDATE `amiyadb`.`tbl_tag_info` SET `description` = '5A' WHERE (`id` = '1');

--医院职位列表新增描述
ALTER TABLE `amiyadb`.`tbl_hospital_position_info` 
ADD COLUMN `description` VARCHAR(150) NULL AFTER `name`;

UPDATE `amiyadb`.`tbl_hospital_position_info` SET `description` = 'Administrator' WHERE (`id` = '1');
UPDATE `amiyadb`.`tbl_hospital_position_info` SET `description` = 'Customer service' WHERE (`id` = '3');
UPDATE `amiyadb`.`tbl_hospital_position_info` SET `description` = 'Doctor' WHERE (`id` = '4');


------------------------------------余建明 2025/10/11 END--------------------------------------

