
-----------------------------------------------王健 2023/1/3 BEGIN--------------------------------------------

--礼品类别

CREATE TABLE `tbl_gift_category` (
	`id` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_unicode_ci',
	`name` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_unicode_ci',
	`simple_code` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_unicode_ci',
	`create_by` INT(10) NOT NULL,
	`update_by` INT(10) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='utf8mb4_unicode_ci'
ENGINE=InnoDB;


-----------------------------------------------王健 2023/1/3 END--------------------------------------------


-----------------------------------------------余建明 2023/1/6 BEGIN--------------------------------------------

--小程序客服自动回复板块新增数据库
CREATE TABLE `amiyadb`.`tbl_miniprogram_auto_send_message` (
  `id` VARCHAR(50) NOT NULL,
  `message` VARCHAR(3000) NOT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2023/1/6 END--------------------------------------------



-----------------------------------------------王健 2023/1/9 BEGIN--------------------------------------------

-----用户及商品标签关联表

CREATE TABLE `tbl_tag_detail_info` (
	`customer_goods_id` VARCHAR(50) NOT NULL,
	`tag_id` VARCHAR(50) NOT NULL
);

-----------------------------------------------王健 2023/1/9 END--------------------------------------------


-----------------------------------------------余建明 2023/1/14 BEGIN--------------------------------------------

CREATE TABLE `amiyadb`.`tbl_recommand_document_settle` (
  `id` VARCHAR(50) NOT NULL,
  `recommand_document_id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NOT NULL,
  `deal_info_id` VARCHAR(50) NULL,
  `order_from` INT NOT NULL,
  `return_back_price` DECIMAL(12,2) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `is_settle` BIT(1) NOT NULL,
  `settle_date` DATETIME NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2023/1/14 END--------------------------------------------



-----------------------------------------------余建明 2023/2/02 BEGIN--------------------------------------------
--未对账订单列表
CREATE TABLE `amiyadb`.`tbl_uncheck_order` (
  `id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NOT NULL,
  `order_from` INT NOT NULL,
  `phone` VARCHAR(11) NOT NULL,
  `deal_date` DATETIME NOT NULL,
  `deal_price` DECIMAL(12,2) NOT NULL,
  `information_price_percent` DECIMAL(4,2) NOT NULL,
  `system_update_percent` DECIMAL(4,2) NOT NULL,
  `information_price` DECIMAL(12,2) NOT NULL,
  `system_update_price` DECIMAL(12,2) NOT NULL,
  `return_back_price` DECIMAL(12,2) NOT NULL,
  `is_submit_reconciliation_documents` BIT(1) NOT NULL,
  `send_hospital` INT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_uncheck_order_createinfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_uncheck_order_createinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
-----------------------------------------------余建明 2023/2/02 END--------------------------------------------



-----------------------------------------------余建明 2023/2/07 BEGIN--------------------------------------------
--新增票据表
CREATE TABLE `amiyadb`.`tbl_bill` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `hospital_id` INT UNSIGNED NOT NULL,
  `bill_price` DECIMAL(12,2) NOT NULL,
  `tax_rate` DECIMAL(3,2) NOT NULL,
  `tax_price` DECIMAL(12,2) NOT NULL,
  `not_in_tax_price` DECIMAL(12,2) NOT NULL,
  `other_price` DECIMAL(12,2) NULL,
  `other_price_remark` VARCHAR(300) NULL,
  `collecting_company_id` VARCHAR(50) NOT NULL,
  `belong_start_time` DATETIME NOT NULL,
  `belong_end_time` DATETIME NOT NULL,
  `bill_type` INT NOT NULL,
  `create_bill_reason` VARCHAR(300) NULL,
  `return_back_state` INT NOT NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_bill_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  INDEX `fk_bill_amiyaemployeeinfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_bill_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_bill_amiyaemployeeinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

    --新增票据回款记录表
    CREATE TABLE `amiyadb`.`tbl_bill_return_back_price_data` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `company_id` VARCHAR(50) NOT NULL,
  `bill_id` VARCHAR(50) NOT NULL,
  `bill_price` DECIMAL(12,2) NOT NULL,
  `other_price` DECIMAL(12,2) NULL,
  `return_back_price` DECIMAL(12,2) NOT NULL,
  `return_back_date` DATETIME NOT NULL,
  `return_back_state` INT NOT NULL,
  `remark` VARCHAR(500) NULL,
  PRIMARY KEY (`id`),
  INDEX `bill_return_back_price_data_createby_idx` (`create_by` ASC) VISIBLE,
  INDEX `fk_bill_return_back_price_data_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  INDEX `fk_bill_return_back_price_data_companyinfo_idx` (`company_id` ASC) VISIBLE,
  INDEX `fk_bill_return_back_price_data_billinfo_idx` (`bill_id` ASC) VISIBLE,
  CONSTRAINT `fk_bill_return_back_price_data_amiyaemployeeinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_bill_return_back_price_data_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_bill_return_back_price_data_companyinfo`
    FOREIGN KEY (`company_id`)
    REFERENCES `amiyadb`.`tbl_company_base_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_bill_return_back_price_data_billinfo`
    FOREIGN KEY (`bill_id`)
    REFERENCES `amiyadb`.`tbl_bill` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/2/07 END--------------------------------------------


----------------------------------------王健 2023/2/16 BEGIN-----------------------------------


-----控制小程序页面显示

CREATE TABLE `tbl_control_page_show` (
	`id` INT(10) NOT NULL,
	`show` BIT(1) NOT NULL DEFAULT 'b\'0\'',
	PRIMARY KEY (`id`) USING BTREE
)
ENGINE=InnoDB;



----------------------------------------王健 2023/2/16 END-----------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



--------------------------------------王健 2023/3/15 BEGIN----------------------------------------

-----系统操作日志

CREATE TABLE `tbl_system_operation_log` (
	`id` VARCHAR(50) NOT NULL,
	`route_address` VARCHAR(500) NOT NULL,
	`request_type` INT(10) NOT NULL,
	`code` INT(10) NOT NULL,
	`parameters` VARCHAR(5000) NULL DEFAULT NULL,
	`message` VARCHAR(5000) NULL DEFAULT NULL,
	`operation_by` INT(10) NULL DEFAULT '0',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT 'b\'0\'',
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);

--------------------------------------王健 2023/3/15 END----------------------------------------



----------------------------------------------王健2023/3/17 BEGIN-----------------------------------------------------


----美学设计报告
CREATE TABLE `tbl_aesthetics_design_report` (
	`id` VARCHAR(50) NOT NULL,
	`customer_id` VARCHAR(50) NOT NULL,
	`name` VARCHAR(50) NOT NULL,
	`birth_day` DATETIME NOT NULL,
	`phone` VARCHAR(50) NOT NULL,
	`has_aesthetic_history` BIT(1) NOT NULL,
	`history_describe1` VARCHAR(3000) NULL DEFAULT NULL,
	`whether_accept_operation` BIT(1) NOT NULL,
	`whether_allergy` BIT(1) NOT NULL,
	`allergy_describe` VARCHAR(3000) NULL DEFAULT NULL,
	`beauty_demand` VARCHAR(3000) NULL DEFAULT NULL,
	`budge` DECIMAL(10,2) NOT NULL,
	`pictrue1` VARCHAR(500) NULL DEFAULT NULL,
	`pictrue2` VARCHAR(500) NULL DEFAULT NULL,
	`status` INT(10) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	`history_describe2` VARCHAR(3000) NULL DEFAULT NULL,
	`history_describe3` VARCHAR(3000) NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


----美学设计
CREATE TABLE `tbl_aesthetics_design` (
	`id` INT NOT NULL,
	`aesthetics_design_report_id` VARCHAR(50) NOT NULL,
	`design` VARCHAR(5000) NULL DEFAULT NULL,
	`simple_hospital_name` VARCHAR(100) NULL DEFAULT NULL,
	`recommend_doctor` VARCHAR(50) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);

----美学设计标签
CREATE TABLE `tbl_aesthetics_design_report_tags` (
	`report_id` VARCHAR(50) NOT NULL,
	`tag_id` VARCHAR(50) NOT NULL
);


----------------------------------------------王健2023/3/17 END-----------------------------------------------------


