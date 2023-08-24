

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
-----------------------------------------------余建明 2023/07/17 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` (
  `id` VARCHAR(50) NOT NULL,
  `warehouse_id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(100) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tbl_warehouse_storage_racks_warehouseinfo_idx` (`warehouse_id` ASC) VISIBLE,
  INDEX `fk_tb_warehouse_storage_racks_empinfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_warehouse_storage_racks_warehouseinfo`
    FOREIGN KEY (`warehouse_id`)
    REFERENCES `amiyadb`.`tbl_amiya_warehouse` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_warehouse_storage_racks_empinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
-----------------------------------------------余建明 2023/07/17 END--------------------------------------------


-----------------------------------------------余建明 2023/07/25 BEGIN--------------------------------------------
--基础数据新增品牌列表
CREATE TABLE `amiyadb`.`tbl_supplier_brand` (
  `id` VARCHAR(50)  NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `brand_name` VARCHAR(100) NULL,
  PRIMARY KEY (`id`));
--基础数据新增品类列表
CREATE TABLE `amiyadb`.`tbl_supplier_category` (
  `id` VARCHAR(50)  NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `category_name` VARCHAR(100) NULL,
  `brand_id` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`id`));
  
--新建直播中每日带货商品列表
CREATE TABLE `amiyadb`.`tbl_living_daily_take_goods` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `brand_id` VARCHAR(50) NOT NULL,
  `category_id` VARCHAR(50) NOT NULL,
  `content_plat_form_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `live_anchor_id` INT UNSIGNED NOT NULL,
  `item_id` INT UNSIGNED NOT NULL,
  `single_price` DECIMAL(12,2) NOT NULL,
  `take_goods_quantity` INT NOT NULL,
  `total_price` DECIMAL(12,2) NOT NULL,
  `take_goods_type` INT NOT NULL DEFAULT 0,
  `remark` VARCHAR(500) NULL ,
  PRIMARY KEY (`id`),
  INDEX `fk_living_daily_take_goods_create_empinfo_idx` (`create_by` ASC) VISIBLE,
  INDEX `fk_living_daily_take_goods_brandinfo_idx` (`brand_id` ASC) VISIBLE,
  INDEX `fk_living_daily_take_goods_categoryinfo_idx` (`category_id` ASC) VISIBLE,
  INDEX `fk_living_daily_take_goods_contentplatforminfo_idx` (`content_plat_form_id` ASC) VISIBLE,
  INDEX `fk_living_daily_take_goods_liveanchorinfo_idx` (`live_anchor_id` ASC) VISIBLE,
  INDEX `fk_living_daily_take_goods_iteminfo_idx` (`item_id` ASC) VISIBLE,
  CONSTRAINT `fk_living_daily_take_goods_create_empinfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_living_daily_take_goods_brandinfo`
    FOREIGN KEY (`brand_id`)
    REFERENCES `amiyadb`.`tbl_supplier_brand` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_living_daily_take_goods_categoryinfo`
    FOREIGN KEY (`category_id`)
    REFERENCES `amiyadb`.`tbl_supplier_category` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_living_daily_take_goods_contentplatforminfo`
    FOREIGN KEY (`content_plat_form_id`)
    REFERENCES `amiyadb`.`tbl_content_platform` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_living_daily_take_goods_liveanchorinfo`
    FOREIGN KEY (`live_anchor_id`)
    REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_living_daily_take_goods_iteminfo`
    FOREIGN KEY (`item_id`)
    REFERENCES `amiyadb`.`tbl_item_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-----------------------------------------------余建明 2023/07/26 END--------------------------------------------

-----------------------------------------------余建明 2023/08/01 BEGIN--------------------------------------------
--基础数据新增品项列表
CREATE TABLE `amiyadb`.`tbl_supplier_item_details` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `item_details_name` VARCHAR(100) NULL,
  `brand_id` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tbl_supplier_item_brandinfo_idx` (`brand_id` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_supplier_item_brandinfo`
    FOREIGN KEY (`brand_id`)
    REFERENCES `amiyadb`.`tbl_supplier_brand` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
-----------------------------------------------余建明 2023/08/01 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



------------------------------------------王健 2023/08/17 BEGIN-------------------------------------------------

-------------直播复盘表主表

CREATE TABLE `tbl_live_replay` (
	`id` VARCHAR(100) NOT NULL,
	`content_platform_id` VARCHAR(50) NOT NULL,
	`liveanchor_id` INT(10) UNSIGNED NOT NULL,
	`live_date` DATE NOT NULL,
	`live_duration` INT(10) NOT NULL DEFAULT '0',
	`gmv` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	`live_personnel` VARCHAR(500) NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT '0',
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`),
	INDEX `fk_to_contentplatform` (`content_platform_id`),
	INDEX `fk_to_liveanchor` (`liveanchor_id`),
	CONSTRAINT `fk_to_contentplatform` FOREIGN KEY (`content_platform_id`) REFERENCES `tbl_content_platform` (`id`) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT `fk_to_liveanchor` FOREIGN KEY (`liveanchor_id`) REFERENCES `tbl_live_anchor` (`id`) ON UPDATE NO ACTION ON DELETE NO ACTION
);


--直播分析流量优化

CREATE TABLE `tbl_live_replay_flow_optimize` (
	`id` VARCHAR(50) NOT NULL,
	`live_replay_id` VARCHAR(50) NOT NULL,
	`flow_source` VARCHAR(100) NOT NULL,
	`proportion` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	`drainage_count` INT(10) NOT NULL DEFAULT '0',
	`last_drainage_count` INT(10) NOT NULL DEFAULT '0',
	`last_drainage_proportion` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	`problem_analysis` VARCHAR(500) NULL DEFAULT NULL,
	`later_solution` VARCHAR(500) NULL DEFAULT NULL,
	`sort` INT(10) NOT NULL DEFAULT '0',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT '0',
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


--直播分析-话术内容
CREATE TABLE `tbl_live_replay_word_analyse` (
	`id` VARCHAR(50) NOT NULL,
	`live_replay_id` VARCHAR(50) NOT NULL,
	`replay_content` VARCHAR(500) NOT NULL,
	`word_manifestation` VARCHAR(500) NULL DEFAULT NULL,
	`problem_analysis` VARCHAR(500) NULL DEFAULT NULL,
	`later_solution` VARCHAR(500) NULL DEFAULT NULL,
	`sort` INT(10) NOT NULL DEFAULT '0',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT '0',
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


------------------------------------------王健 2023/08/17 END-------------------------------------------------
-----------------------------------------------余建明 2023/08/18 BEGIN--------------------------------------------
--直播复盘-成交数据
CREATE TABLE `amiyadb`.`tbl_live_replay_product_deal_data` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `live_replay_id` VARCHAR(50) NOT NULL,
  `replay_target` VARCHAR(100) NULL,
  `data_target` DECIMAL(12,2) NOT NULL,
  `last_living_data` DECIMAL(12,2) NOT NULL,
  `last_living_compare` DECIMAL(12,2) NOT NULL,
  `question_analize` VARCHAR(3000) NULL,
  `later_period_solution` VARCHAR(3000) NULL,
  `sort` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_to_live_replay_idx` (`live_replay_id` ASC) VISIBLE,
  CONSTRAINT `fk_to_live_replay`
    FOREIGN KEY (`live_replay_id`)
    REFERENCES `amiyadb`.`tbl_live_replay` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
--直播复盘-互动数据
CREATE TABLE `amiyadb`.`tbl_live_replay_interactionl_data` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `live_replay_id` VARCHAR(50) NOT NULL,
  `replay_target` VARCHAR(100) NULL,
  `data_target` DECIMAL(12,2) NOT NULL,
  `last_living_data` DECIMAL(12,2) NOT NULL,
  `last_living_compare` DECIMAL(12,2) NOT NULL,
  `question_analize` VARCHAR(3000) NULL,
  `later_period_solution` VARCHAR(3000) NULL,
  `sort` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_to_live_replay_idx` (`live_replay_id` ASC) VISIBLE,
  CONSTRAINT `fk_to_live_replay`
    FOREIGN KEY (`live_replay_id`)
    REFERENCES `amiyadb`.`tbl_live_replay` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

	--直播复盘-商品分析数据
	CREATE TABLE `amiyadb`.`tbl_live_replay_merchandise_top_data` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `live_replay_id` VARCHAR(50) NOT NULL,
  `sort` INT NOT NULL,
  `merchandise_name` VARCHAR(500) NOT NULL,
  `gmv` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `merchandise_show_num` INT NOT NULL DEFAULT 0,
  `merchandise_visit_num` INT NOT NULL DEFAULT 0,
  `merchandise_show_visit_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `merchandise_create_order_num` INT NOT NULL DEFAULT 0,
  `merchandise_visit_create_order_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `merchandise_deal_num` INT NOT NULL DEFAULT 0,
  `merchandise_create_order_deal_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `merchandise_question` VARCHAR(500) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_to_live_replay_idx` (`live_replay_id` ASC) VISIBLE,
  CONSTRAINT `fk_live_replay_merchandise_top_data_to_live_replay`
    FOREIGN KEY (`live_replay_id`)
    REFERENCES `amiyadb`.`tbl_live_replay` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/08/22 END--------------------------------------------

