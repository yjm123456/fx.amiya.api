

------------------------------------------王健 2023/07/03 BEGIN--------------------------------------


---rfm客户详情
CREATE TABLE `tbl_rmf_customerinfo` (
	`id` VARCHAR(50) NOT NULL,
	`customer_service_id` INT(10) NULL DEFAULT NULL,
	`phone` VARCHAR(50) NULL DEFAULT NULL,
	`last_deal_date` DATETIME NULL DEFAULT NULL,
	`hospital_id` INT(10) NULL DEFAULT NULL,
	`deal_price` DECIMAL(10,2) NOT NULL,
	`total_deal_price` DECIMAL(10,2) NOT NULL,
	`consumption_frequency` INT(10) NOT NULL,
	`recency_date` INT(10) NOT NULL DEFAULT 0,
	`recency` INT(10) NOT NULL,
	`frequency` INT(10) NOT NULL,
	`monetary` INT(10) NOT NULL,
	`rfm_tag` INT(10) NOT NULL,
	`live_anchor_wechatno` VARCHAR(100) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);




------------------------------------------王健 2023/07/03 END--------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上

------------------------------------------余建明 2023/07/13 END--------------------------------------
--新增客户RFM等级刷新记录
CREATE TABLE `amiyadb`.`tbl_bind_customer_rfm_level_update_log` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `bind_customer_service_id` INT UNSIGNED NOT NULL,
  `customer_service_id` INT UNSIGNED NOT NULL,
  `from` INT NOT NULL,
  `to` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_bind_customer_update_log_bindcustomerserviceid_idx` (`bind_customer_service_id` ASC) VISIBLE,
  INDEX `fk_bind_customer_rfm_level_log_empinfo_idx` (`customer_service_id` ASC) VISIBLE,
  CONSTRAINT `fk_bind_customer_update_log_bindcustomerserviceid`
    FOREIGN KEY (`bind_customer_service_id`)
    REFERENCES `amiyadb`.`tbl_bind_customer_service` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_bind_customer_rfm_level_log_empinfo`
    FOREIGN KEY (`customer_service_id`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
------------------------------------------余建明 2023/07/13 END--------------------------------------


