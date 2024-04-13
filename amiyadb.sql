


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

--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上
--新增助理月度业绩目标
CREATE TABLE `amiyadb`.`tbl_employee_performance_target` (
  `id` VARCHAR(50) NOT NULL,
  `belong_year` INT NOT NULL,
  `belong_month` INT NOT NULL,
  `employee_id` INT UNSIGNED NOT NULL,
  `consulation_card_target` INT NOT NULL DEFAULT 0,
  `add_wechat_target` INT NOT NULL DEFAULT 0,
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
  `project_url` VARCHAR(45) NOT NULL,
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



