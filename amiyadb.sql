
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

------------------------------------余建明 2024/10/11 BEGIN--------------------------------------
--助理阶梯薪资基础配置表
CREATE TABLE `amiyadb`.`tbl_employee_performance_ladder` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `customer_service_id` INT NULL,
  `is_personal_config` BIT(1) NOT NULL,
  `performance_lower_limit` DECIMAL(12,2) NOT NULL,
  `performance_upper_limit` DECIMAL(12,2) NOT NULL,
  `base_performance` DECIMAL(12,2) NOT NULL,
  `year` INT NOT NULL,
  `month` INT NOT NULL,
  `remark` VARCHAR(500) NULL
  `point` DECIMAL(12,2) NOT NULL,
  PRIMARY KEY (`id`));

  --新增助理新板块薪资待生成表格
  CREATE TABLE `amiyadb`.`tbl_customer_service_check_performance` (
  `id` VARCHAR(50) NOT NULL,
  `deal_info_id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NOT NULL,
  `order_from` INT NOT NULL,
  `deal_price`  DECIMAL(12,2) NOT NULL,
  `deal_create_date` DATETIME NOT NULL,
  `performance_type` INT NOT NULL,
  `belong_emp_id` INT UNSIGNED NOT NULL,
  `point` DECIMAL(12,2) NOT NULL,
  `check_emp_id` INT NULL,
  `remark` VARCHAR(500) NULL,
  `bill_id` VARCHAR(50) NULL,
  `check_bill_id` VARCHAR(50) NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL DEFAULT b'0',
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_belong_employee_idx` (`belong_emp_id` ASC) VISIBLE,
  CONSTRAINT `fk_belong_employee`
    FOREIGN KEY (`belong_emp_id`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


------------------------------------余建明 2024/10/11 END--------------------------------------

--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------
