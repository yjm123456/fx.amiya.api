



-----------------------------------------------王健 2023/07/03 BEGIN--------------------------------------------

-----微信支付信息字段长度修改
ALTER TABLE `tbl_wechat_payinfo`
	CHANGE COLUMN `sub_app_id` `sub_app_id` VARCHAR(5000) NOT NULL AFTER `enablesp`,
	CHANGE COLUMN `sub_mch_id` `sub_mch_id` VARCHAR(5000) NOT NULL AFTER `sub_app_id`;

-----------------------------------------------王健 2023/07/03 BEGIN--------------------------------------------

-----------------------------------------------余建明 2023/07/07 END--------------------------------------------
--小黄车登记列表新增带货板块产品类型
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `product_type` INT NOT NULL DEFAULT 0 AFTER `source`;
-----------------------------------------------余建明 2023/07/07 END--------------------------------------------

--绑定客服列表新增RFM类型
ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `rfm_type` INT NOT NULL DEFAULT 0 AFTER `consumption_date`;
-----------------------------------------------余建明 2023/07/11 END--------------------------------------------


------------------------------------------------王健 2023/07/13 BEGIN--------------------------------------------

----修改支付信息表字段
ALTER TABLE `tbl_wechat_payinfo`
	CHANGE COLUMN `sub_app_id` `sub_app_id` VARCHAR(50) NOT NULL  AFTER `enablesp`,
	CHANGE COLUMN `sub_mch_id` `sub_mch_id` VARCHAR(50) NOT NULL  AFTER `sub_app_id`,
	ADD COLUMN `private_key` VARCHAR(5000) NOT NULL AFTER `sub_mch_id`,
	ADD COLUMN `public_key` VARCHAR(5000) NOT NULL AFTER `private_key`,
	ADD COLUMN `store_id` VARCHAR(50) NOT NULL AFTER `public_key`;

----添加证书名称字段
ALTER TABLE `tbl_wechat_payinfo`
	ADD COLUMN `certificate_name` VARCHAR(500) NULL DEFAULT NULL AFTER `delete_date`;


-------------------------------------------------王健 2023/07/13 END-------------------------------------------------


-----------------------------------------------余建明 2023/07/17 BEGIN--------------------------------------------
--小黄车登记列表新增获客方式
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `get_customer_type` INT NOT NULL DEFAULT 0 AFTER `product_type`;

--库存板块新增货架id
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD COLUMN `storage_racks_id` VARCHAR(50) NULL AFTER `total_price`;

--货架管理主外键更改
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
DROP FOREIGN KEY `fk_tbl_warehouse_storage_racks_warehouseinfo`;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
ADD INDEX `fk_tbl_warehouse_storage_racks_warehouseinfo_idx` (`warehouse_id` ASC) VISIBLE,
DROP INDEX `fk_tbl_warehouse_storage_racks_warehouseinfo_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse_storage_racks` 
ADD CONSTRAINT `fk_tbl_warehouse_storage_racks_warehouseinfo`
  FOREIGN KEY (`warehouse_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse_name_manage` (`id`);

-----------------------------------------------余建明 2023/07/17 END--------------------------------------------


-----------------------------------------------余建明 2023/07/20 BEGIN--------------------------------------------
--升单加入审核助理服务费
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2)  NULL   AFTER `check_settle_price`;
-----------------------------------------------余建明 2023/07/20 END--------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上

-----------------------------------------------余建明 2023/07/25 BEGIN--------------------------------------------
--品类列表加入品牌主外键
ALTER TABLE `amiyadb`.`tbl_supplier_category` 
ADD INDEX `fk_tbl_supplier_category_brandinfo_idx` (`brand_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_supplier_category` 
ADD CONSTRAINT `fk_tbl_supplier_category_brandinfo`
  FOREIGN KEY (`brand_id`)
  REFERENCES `amiyadb`.`tbl_supplier_brand` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --项目列表加入品牌品类相关数据和平台数据
  ALTER TABLE `amiyadb`.`tbl_item_info` 
ADD COLUMN `app_type` INT NOT NULL DEFAULT 0 AFTER `live_price`,
ADD COLUMN `brand_id` VARCHAR(50) NOT NULL AFTER `other_app_item_id`,
ADD COLUMN `category_id` VARCHAR(50) NOT NULL AFTER `brand_id`;

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
