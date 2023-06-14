-----------------------------------------------王健 2023/03/31 BEGIN--------------------------------------------

--------微信视频号订单
CREATE TABLE `tbl_wechatvideo_order_info` (
	`id` VARCHAR(100) NOT NULL,
	`goods_name` VARCHAR(500) NOT NULL,
	`goods_id` VARCHAR(50) NOT NULL,
	`phone` VARCHAR(20) NULL DEFAULT NULL,
	`status_code` VARCHAR(50) NULL DEFAULT NULL,
	`actual_payment` DECIMAL(10,2) NULL DEFAULT NULL,
	`account_receivable` DECIMAL(10,2) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`thumb_pic_url` VARCHAR(500) NULL DEFAULT NULL,
	`buyer_nick` VARCHAR(225) NULL DEFAULT NULL,
	`order_type` BIGINT(19) NULL DEFAULT NULL,
	`quantity` INT(10) NULL DEFAULT NULL,
	`belong_emp_id` INT(10) NOT NULL,
	`check_state` INT(10) NULL DEFAULT NULL,
	`check_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_date` DECIMAL(10,2) NULL DEFAULT NULL,
	`settle_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_by` INT(10) NULL DEFAULT NULL,
	`check_remark` VARCHAR(300) NULL DEFAULT NULL,
	`is_return_back_price` BIT(1) NOT NULL,
	`return_back_price` DECIMAL(12,2) NULL DEFAULT NULL,
	`return_back_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT(10) NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);



-----------------------------------------------王健 2023/03/31 END--------------------------------------------
-----------------------------------------------余建明 2023/04/13 BEGIN--------------------------------------------

--新增客户预约日程表
CREATE TABLE `amiyadb`.`tbl_customer_appointment_schedule` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `appointment_type` INT  NOT NULL,  
  `customer_name` VARCHAR(100) NULL,
  `phone` VARCHAR(50) NULL,
  `appointment_date` DATETIME NOT NULL,
  `is_finish` BIT(1) NOT NULL,
  `important_type` INT NOT NULL,
  `remark` VARCHAR(300) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_customer_appointment_schedule_createempInfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_customer_appointment_schedule_createempInfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


	--新增通知动态板块功能数据表
	CREATE TABLE `amiyadb`.`tbl_message_notice` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `accept_by` INT UNSIGNED NOT NULL,
  `is_read` BIT(1) NOT NULL,
  `notice_type` INT NOT NULL,
  `notice_content` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tbl_message_notice_empinfo_idx` (`accept_by` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_message_notice_empinfo`
    FOREIGN KEY (`accept_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/04/13 END--------------------------------------------


----------------------------------------------王健 2023/04/20 BEGIN--------------------------------

------记录用户最近一次登录的appid
CREATE TABLE `tbl_user_lasttime_loginappid` (
	`id` VARCHAR(50) NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL,
	`user_id` VARCHAR(100) NOT NULL,
	`app_id` VARCHAR(50) NOT NULL,
	PRIMARY KEY (`id`) USING BTREE
);


--商品分类
CREATE TABLE `tbl_category_to_goods` (
	`id` VARCHAR(50) NOT NULL DEFAULT '',
	`goods_id` VARCHAR(50) NOT NULL DEFAULT '',
	`category_id` INT NOT NULL DEFAULT 0
);


---小程序信息

CREATE TABLE `tbl_miniprogram` (
	`id` VARCHAR(100) NOT NULL,
	`name` VARCHAR(100) NOT NULL,
	`appid` VARCHAR(100) NOT NULL,
	`is_main` BIT(1) NOT NULL,
	`belong_live_anchor_id` INT(10) NULL DEFAULT 0,
	`belong_appId` VARCHAR(100) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


----------------------------------------------王健 2023/04/20 END--------------------------------


-----------------------------------------------余建明 2023/05/13 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_content_platform_order_deal_details` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `goods_name` VARCHAR(300) NULL,
  `goods_spec` VARCHAR(45) NULL,
  `quantity` INT NOT NULL DEFAULT 0,
  `price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `content_platform_order_deal_id` VARCHAR(50) NULL,
  `content_platform_order_id` VARCHAR(50) NULL,
  `create_by` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2023/05/13 END--------------------------------------------


-----------------------------------------------王健 2023/05/17 BEGIN--------------------------------------

----健康值
CREATE TABLE `tbl_heath_value` (
	`id` VARCHAR(100) NOT NULL,
	`name` VARCHAR(200) NOT NULL,
	`code` VARCHAR(200) NOT NULL,
	`value` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);

-----------------------------------------------王健 2023/05/17 END--------------------------------------
-----------------------------------------------余建明 2023/05/23 BEGIN--------------------------------------------
--客户医院消费列表
CREATE TABLE `amiyadb`.`tbl_customer_hospital_deal_info` (
  `id` VARCHAR(50) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `type` INT NOT NULL,
  `customer_name` VARCHAR(45) NOT NULL,
  `customer_phone` VARCHAR(30) NOT NULL,
  `date` DATETIME NOT NULL,
  `total_amount` DECIMAL(12,2) NOT NULL,
  `consumption_type` INT NULL,
  `refund_type` INT NULL,
  `msg_id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_customer_hospital_deal_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_customer_hospital_deal_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


	--客户医院消费详情
	CREATE TABLE `amiyadb`.`tbl_customer_hospital_deal_details` (
  `id` VARCHAR(50) NOT NULL,
  `customer_hospital_deal_id` VARCHAR(50) NOT NULL,
  `item_name` VARCHAR(300) NULL,
  `item_standard` VARCHAR(400) NULL,
  `quantity` DECIMAL(12,2) NULL,
  `cash_amount` DECIMAL(12,2) NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `tbl_customer_hospital_deal_details_deal_info_idx` (`customer_hospital_deal_id` ASC) VISIBLE,
  CONSTRAINT `tbl_customer_hospital_deal_details_deal_info`
    FOREIGN KEY (`customer_hospital_deal_id`)
    REFERENCES `amiyadb`.`tbl_customer_hospital_deal_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/05/23 END--------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



------------------------------------------王健 2023/06/14 BEGIN--------------------------------------


----微信支付信息
CREATE TABLE `tbl_wechat_payinfo` (
	`id` VARCHAR(50) NOT NULL ,
	`app_id` VARCHAR(50) NOT NULL,
	`app_secret` VARCHAR(50) NOT NULL,
	`partner_id` VARCHAR(50) NOT NULL,
	`partner_key` VARCHAR(50) NOT NULL,
	`enablesp` BIT(1) NOT NULL DEFAULT 0,
	`sub_app_id` VARCHAR(50) NOT NULL,
	`sub_mch_id` VARCHAR(50) NOT NULL,
	`remark` VARCHAR(200) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL
);

------------------------------------------王健 2023/06/14 END--------------------------------------