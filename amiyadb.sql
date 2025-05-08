


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

------------------------------------余建明 2025/05/08 BEGIN--------------------------------------
--新增润棠运营添加反馈表
CREATE TABLE `amiyadb`.`tbl_runtang_date_operation` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `delete_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `live_anchor_base_id` VARCHAR(50) NOT NULL,
  `customer_add_num` INT NOT NULL,
  `company_add_num` INT NOT NULL,
  `total_add_num` INT NOT NULL,
  `effictive_communication_num` INT NOT NULL,
  `effictive_communication_rate` DECIMAL(12,2) NOT NULL,
  `invalid_customer_num` INT NOT NULL,
  `effictive_customer_num` INT NOT NULL,
  `effictive_customer_rate` DECIMAL(12,2) NOT NULL,
  `remark` VARCHAR(500) NULL,
  `record_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_runtang_amiya_empinfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_runtang_amiya_empinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
------------------------------------余建明 2025/05/08 END--------------------------------------
