-----------------------------------------------余建明 2021/08/10 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_goods_hospital_price` (
  `goods_id` VARCHAR(50) NOT NULL,
  `hospital_id` INT NOT NULL,
  `price` DECIMAL(10,2) NOT NULL DEFAULT 0.00);

  

  CREATE TABLE `amiyadb`.`tbl_order_write_off_info` (
  `id` VARCHAR(100) NOT NULL,
  `create_date` DATETIME NULL,
  `write_off_order_id` VARCHAR(100) NULL,
  `write_off_amount` INT NOT NULL,
  `order_least_amount` INT NOT NULL DEFAULT 0,
  `write_off_goods` VARCHAR(200) NULL,
  `write_off_hospitalid` VARCHAR(50) NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/08/10 END--------------------------------------------

--------------【1.2版本更新分支数据库更改】

-----------------------------------------------余建明 2021/09/04 BEGIN--------------------------------------------
--物流公司表
CREATE TABLE `amiyadb`.`tbl_amiya_express` (
  `id` VARCHAR(50) NOT NULL,
  `express_name` VARCHAR(45) NOT NULL,
  `express_code` VARCHAR(100) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));



-----------------------------------------------余建明 2021/09/04 END--------------------------------------------


-----------------------------------------------余建明 2021/09/07 BEGIN--------------------------------------------
  --医院科室表
  CREATE TABLE `amiyadb`.`tbl_amiya_hospital_department` (
  `id` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  `department_name` VARCHAR(100) NULL,
  `description` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));

  --商品需求表
  CREATE TABLE `amiyadb`.`tbl_amiya_goods_demand` (
  `id` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  `hospital_department_id` VARCHAR(50) NULL,
  `project_name` VARCHAR(200) NULL,
  `description` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));

-----------------------------------------------余建明 2021/09/07 END--------------------------------------------


-----------------------------------------------余建明 2021/09/22 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_province` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/09/22 END--------------------------------------------



-----------------------------------------------余建明 2021/09/23 BEGIN--------------------------------------------

CREATE TABLE `amiyadb`.`tbl_beauty_diary_tag_info` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));

  
CREATE TABLE `amiyadb`.`tbl_beauty_diary_manage` (
  `id` VARCHAR(50) NOT NULL,
  `cover_title` VARCHAR(300) NULL,
  `details_title` VARCHAR(300) NULL,
  `release_state` BIT(1) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `views` INT NOT NULL DEFAULT 0,
  `giving_likes` INT NOT NULL DEFAULT 0,
  `thumb_picture_url` VARCHAR(500) NULL,
  `video_url` VARCHAR(500) NULL,
  `details_description` VARCHAR(9999) NULL ,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_beauty_diary_banner_image` (
  `id` VARCHAR(50) NOT NULL,
  `beauty_diary_id` VARCHAR(50) NOT NULL,
  `pic_url` VARCHAR(500) NOT NULL,
  `display_index` TINYINT NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_beauty_diary_tag_detail` (
  `id` VARCHAR(50) NOT NULL,
  `beauty_diary_id` VARCHAR(50) NOT NULL,
  `tag_id` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_beautyDiaryTagDetail_tagid_beautyDiaryTagInfo_id_idx` (`tag_id` ASC) VISIBLE,
  INDEX `fx_beautyDiaryTagDetail_beautyDiaryid_beautyDiaryManage_id_idx` (`beauty_diary_id` ASC) VISIBLE,
  CONSTRAINT `fk_beautyDiaryTagDetail_tagid_beautyDiaryTagInfo_id`
    FOREIGN KEY (`tag_id`)
    REFERENCES `amiyadb`.`tbl_beauty_diary_tag_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fx_beautyDiaryTagDetail_beautyDiaryid_beautyDiaryManage_id`
    FOREIGN KEY (`beauty_diary_id`)
    REFERENCES `amiyadb`.`tbl_beauty_diary_manage` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-----------------------------------------------余建明 2021/09/23 END--------------------------------------------



-----------------------------------------------余建明 2021/11/10 BEGIN--------------------------------------------

CREATE TABLE `amiyadb`.`tbl_content_platform` (
  `id` VARCHAR(45)  NOT NULL,
  `content_platform_name` VARCHAR(45)  NOT NULL ,
  `valid` BIT NOT NULL,
  PRIMARY KEY (`id`));


  CREATE TABLE `amiyadb`.`tbl_content_plateform_order` (
  `id` VARCHAR(50) NOT NULL,
  `order_type` INT NULL,
  `content_plateform_id` VARCHAR(50) NULL,
  `live_anchor_id` INT NULL,
  `create_date` DATETIME NULL,
  `update_date` DATETIME NULL,
  `customer_name` VARCHAR(50) NULL,
  `phone` VARCHAR(20) NULL,
  `appointment_date` DATETIME NULL,
  `appointment_hospital_id` VARCHAR(50) NULL,
  `order_status` INT NULL,
  `deposit_amount` DECIMAL(10,2) NULL,
  `deal_amount` DECIMAL(10,2) NULL,
  `deal_picture_url` VARCHAR(200) NULL,
  `repeat_order_picture_url` VARCHAR(200) NULL,
  `undeal_reason` VARCHAR(200) NULL,
  `late_project_stage` VARCHAR(200) NULL,
  `consulting_content` VARCHAR(200) NULL,
  `remark` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));


-----------------------------------------------余建明 2021/11/10 END--------------------------------------------






-----------------------------------------------侯宝平 2021/11/10 BEGIN--------------------------------------------;
--内容平台派单表
CREATE TABLE `amiyadb`.`tbl_content_platform_order_send`  (
  `id` int(32) UNSIGNED NOT NULL AUTO_INCREMENT,
  `content_platform_order_id` varchar(50) NOT NULL,
  `hospital_id` int(32) UNSIGNED NOT NULL,
  `sender` int(32) UNSIGNED NOT NULL,
  `send_date` datetime NOT NULL,
  `is_uncertain_date` bit NOT NULL COMMENT '是否未明确时间',
  `appointment_date` datetime NULL,
  `remark` varchar(500) NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_contentPlatformSendOrder_orderId_contentPlatformOrder_id` FOREIGN KEY (`content_platform_order_id`) REFERENCES `amiyadb`.`tbl_content_platform_order` (`id`),
  CONSTRAINT `fk_contentPlatformSendOrder_sender_amiyaEmployee_id` FOREIGN KEY (`sender`) REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
);
-----------------------------------------------侯宝平 2021/11/10 END--------------------------------------------;




-----------------------------------------------余建明 2021/12/4 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_employee_bind_liveanchor` (
  `id` VARCHAR(50) NOT NULL,
  `employee_id` INT NOT NULL,
  `live_anchor_id` INT NOT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/12/4 END--------------------------------------------;




-----------------------------------------------余建明 2021/12/9 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_notice_config` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(45) NULL,
  `state` BIT(1) NULL,
  PRIMARY KEY (`id`));

  INSERT INTO `amiyadb`.`tbl_notice_config` (`id`, `name`, `state`) VALUES ('4e4e9564-f6c3-47b6-a7da-e4518bab66cf', 'EMailNoticeConfig', b'0');

-----------------------------------------------余建明 2021/12/9 END--------------------------------------------;

-----------------------------------------------余建明 2021/12/24 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_content_platform_order_deal_info` (
  `id` NVARCHAR(50) NOT NULL,
  `content_platform_order_id`  NVARCHAR(50) NULL,
  `create_date` DATETIME NOT NULL,
  `is_to_hospital` BIT(1) NOT NULL DEFAULT 0,
  `is_deal` BIT(1) NOT NULL DEFAULT 0,
  `deal_picture` VARCHAR(200) NULL,
  `remark` VARCHAR(200) NULL,
  `price` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/12/24 END--------------------------------------------;
