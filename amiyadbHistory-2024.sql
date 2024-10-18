---------------First Season Begin----


------------------------------------------王健  2024/1/18 BEGIN------------------------------------------

--飞书表格信息
CREATE TABLE `tbl_feishu_table` (
	`id` VARCHAR(50) NOT NULL,
	`app_token` VARCHAR(100) NOT NULL,
	`table_id` VARCHAR(100) NOT NULL DEFAULT '',
	`belong_app_id` VARCHAR(100) NOT NULL DEFAULT '',
	`table_type` INT NOT NULL,
	`live_anchorId` INT NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);


--短视频评论数据
CREATE TABLE `tbl_short_video_comments` (
	`id` VARCHAR(50) NOT NULL,
	`comments_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_name` VARCHAR(500) NULL DEFAULT NULL,
	`like_count` INT NOT NULL DEFAULT 0,
	`comments` VARCHAR(1000) NULL DEFAULT NULL,
	`comments_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT NOT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


---短视频粉丝数据
CREATE TABLE `tbl_short_video_fans_data` (
	`id` VARCHAR(50) NOT NULL,
	`stats_date` DATETIME NOT NULL,
	`new_fans_count` INT NOT NULL DEFAULT 0,
	`total_fans_count` INT NOT NULL DEFAULT 0,
	`belong_live_anchor_id` INT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL
);
------------------------------------------王健  2024/1/18 END------------------------------------------
---------------First Season End----


---------------Second Season Begin----


	
------------------------------------------余建明  2024/04/10 BEGIN------------------------------------------
--新增助理月度业绩目标
CREATE TABLE `amiyadb`.`tbl_employee_performance_target` (
  `id` VARCHAR(50) NOT NULL,
  `belong_year` INT NOT NULL,
  `belong_month` INT NOT NULL,
  `employee_id` INT UNSIGNED NOT NULL,
  `effective_add_wechat_target` INT(10) NOT NULL DEFAULT '0',
  `potential_add_wechat_target` INT(10) NOT NULL DEFAULT '0',
  `effective_consulation_card_target` INT(10) NOT NULL DEFAULT '0',
  `potential_consulation_card_target` INT(10) NOT NULL DEFAULT '0',
  `send_order_target` INT NOT NULL DEFAULT 0,
  `visit_target` INT NOT NULL DEFAULT 0,
  `new_customer_deal_target` INT NOT NULL DEFAULT 0,
  `old_customer_deal_target` INT NOT NULL DEFAULT 0,
  `new_customer_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `old_customer_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `delete_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_employee_performance_idx` (`employee_id` ASC) VISIBLE,
  CONSTRAINT `fk_employee_performance`
    FOREIGN KEY (`employee_id`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

	--新增医院项目介绍ppt存储表
	CREATE TABLE `amiyadb`.`tbl_hospital_project` (
  `id` VARCHAR(50) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `name` VARCHAR(500) NOT NULL,
  `project_url` VARCHAR(500) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_hospital_project_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_hospital_project_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
------------------------------------------余建明  2024/04/10 END------------------------------------------

	


------------------------------------------余建明  2024/04/21 BEGIN------------------------------------------
--新增粉丝见面会基础信息表
CREATE TABLE `amiyadb`.`tbl_fans_meeting` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `name` VARCHAR(100) NOT NULL,
  `start_date` DATETIME NOT NULL,
  `end_date` DATETIME NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_fansmeeting_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_fansmeeting_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

	--新增粉丝见面会详情信息表
	CREATE TABLE `amiyadb`.`tbl_fans_meeting_details` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `fans_meeting_id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NULL,
  `appointment_date` DATETIME NULL,
  `appointment_details_date` VARCHAR(45) NULL,
  `customer_name` VARCHAR(100) NULL,
  `phone` VARCHAR(30) NULL,
  `customer_quantity` INT NOT NULL,
  `is_old_customer` BIT(1) NOT NULL,
  `amiya_consulation_id` INT UNSIGNED NOT NULL,
  `hospital_consulation_name` VARCHAR(30) NULL,
  `city` VARCHAR(45) NULL,
  `travel_information` VARCHAR(500) NULL,
  `is_need_driver` BIT(1) NOT NULL,
  `hotel_plan` VARCHAR(500) NULL,
  `plan_consumption` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `remark` VARCHAR(500) NULL,
  `customer_picture_url` VARCHAR(300) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_fans_meeting_info_idx` (`fans_meeting_id` ASC) VISIBLE,
  INDEX `fk_amiya_employee_info_idx` (`amiya_consulation_id` ASC) VISIBLE,
  CONSTRAINT `fk_fans_meeting_info`
    FOREIGN KEY (`fans_meeting_id`)
    REFERENCES `amiyadb`.`tbl_fans_meeting` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_amiya_employee_info`
    FOREIGN KEY (`amiya_consulation_id`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


------------------------------------------余建明  2024/04/21 END------------------------------------------
---------------Second Season End------
---------------Third Season Begin----
------------------------------------王健 2024/8/6 BEGIN--------------------------------------
---直播中带货订单表
CREATE TABLE `tbl_living_take_goods_order` (
	`id` VARCHAR(100) NOT NULL,
	`goods_id` VARCHAR(100) NOT NULL,
	`goods_name` VARCHAR(500) NOT NULL,
	`order_status` INT NOT NULL DEFAULT 0,
	`live_anchor_name` VARCHAR(50) NOT NULL,
	`deal_price` DECIMAL(10,2) NOT NULL DEFAULT 0,
	`goods_count` INT NOT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);

ALTER TABLE `tbl_living_take_goods_order`
	ADD PRIMARY KEY (`id`);

------------------------------------王健 2024/8/6 END--------------------------------------


------------------------------------王健 2024/8/14 BEGIN--------------------------------------

--小程序预约活动
CREATE TABLE `tbl_appointment_activity` (
	`id` VARCHAR(50) NOT NULL,
	`user_id` VARCHAR(50) NOT NULL,
	`is_appointment` BIT NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);

------------------------------------王健 2024/8/14 END--------------------------------------


------------------------------------余建明 2024/8/14 BEGIN--------------------------------------
--三方平台基础信息
CREATE TABLE `amiyadb`.`tbl_third_part_contentplatform_info` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`));

--医院平台编码
CREATE TABLE `amiyadb`.`tbl_hospital_contentplatform_code` (
  `id` VARCHAR(50) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `third_part_contentplatform` VARCHAR(50) NOT NULL,
  `code` VARCHAR(45) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`));
------------------------------------余建明 2024/8/14 END--------------------------------------
---------------Third Season End------
---------------Fourth Season Begin----


---------------Fourth Season End------