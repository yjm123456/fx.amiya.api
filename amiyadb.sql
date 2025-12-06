



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
