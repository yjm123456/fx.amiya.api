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
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上
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
