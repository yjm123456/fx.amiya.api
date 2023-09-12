



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
ADD COLUMN `app_type`  VARCHAR(100)  NULL AFTER `live_price`,
ADD COLUMN `brand_id` VARCHAR(50) NOT NULL AFTER `other_app_item_id`,
ADD COLUMN `category_id` VARCHAR(50) NOT NULL AFTER `brand_id`;



-----------------------------------------------余建明 2023/07/26 END--------------------------------------------
-------------------------------------------------------------------
--带货列表新增带货时间
ALTER TABLE `amiyadb`.`tbl_living_daily_take_goods` 
ADD COLUMN `take_goods_date` DATETIME NULL AFTER `delete_date`;
-----------------------------------------------余建明 2023/07/28 END--------------------------------------------



-------------------------------------------------王健 2023/07/31 BEGIN-----------------------------------------------------------------


---直播中月目标添加退款,累计退款gmv,退款gmv完成率
ALTER TABLE `tbl_liveanchor_monthly_target_living`
	ADD COLUMN `refund_gmv_target` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `eliminate_card_gmv_target_complete_rate`,
	ADD COLUMN `refund_gmv_target_completerate` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `refund_gmv_target`,
	ADD COLUMN `cumulative_refund_gmv` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `refund_gmv_target_completerate`;


----直播中日数据添加退款gmv
ALTER TABLE `tbl_living_daily_target`
	ADD COLUMN `refund_gmv` DECIMAL(10,2) NOT NULL DEFAULT '0.00' AFTER `eliminate_card_gmv`;



-------------------------------------------------王健 2023/07/31 END-----------------------------------------------------------------

-----------------------------------------------余建明 2023/08/01 BEGIN--------------------------------------------
--直播带货数据新增品项列与主外键关系
ALTER TABLE `amiyadb`.`tbl_living_daily_take_goods` 
ADD COLUMN `item_details_id` VARCHAR(50) NOT NULL AFTER `remark`,
ADD INDEX `fk_living_daily_take_goods_supplieritemdetailsinfo_idx` (`item_details_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_living_daily_take_goods` 
ADD CONSTRAINT `fk_living_daily_take_goods_supplieritemdetailsinfo`
  FOREIGN KEY (`item_details_id`)
  REFERENCES `amiyadb`.`tbl_supplier_item_details` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --带货商品列表新增品项列
  ALTER TABLE `amiyadb`.`tbl_item_info` 
ADD COLUMN `item_details_id` VARCHAR(50) NOT NULL AFTER `category_id`;

--取消品类对品牌的关联关系
ALTER TABLE `amiyadb`.`tbl_supplier_category` 
DROP FOREIGN KEY `fk_tbl_supplier_category_brandinfo`;
ALTER TABLE `amiyadb`.`tbl_supplier_category` 
DROP COLUMN `brand_id`,
DROP INDEX `fk_tbl_supplier_category_brandinfo_idx` ;
;

-----------------------------------------------余建明 2023/08/01 END--------------------------------------------




-----------------------------------------------余建明 2023/08/08 BEGIN--------------------------------------------
--内容平台订单列表新增获客方式
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `get_customer_type` INT NOT NULL DEFAULT 0 AFTER `belong_company`;

--直播带货数据新增订单量
ALTER TABLE `amiyadb`.`tbl_living_daily_take_goods` 
ADD COLUMN `order_num` INT NOT NULL DEFAULT 0 AFTER `item_details_id`;

-----------------------------------------------余建明 2023/08/9 END--------------------------------------------


-----------------------------------------------余建明 2023/08/14 BEGIN--------------------------------------------
--对账单审核记录新增对账医院
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `hospital_id` INT NOT NULL DEFAULT 0 AFTER `account_price`;
-----------------------------------------------余建明 2023/08/14 END--------------------------------------------


-----------------------------------------------余建明 2023/08/22 BEGIN--------------------------------------------
	--直播复盘-商品分析数据加入商品主外键
ALTER TABLE `amiyadb`.`tbl_live_replay_merchandise_top_data` 
CHANGE COLUMN `merchandise_name` `item_id` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_live_replay_merchandise_top_data_to_item_info_idx` (`item_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_live_replay_merchandise_top_data` 
ADD CONSTRAINT `fk_live_replay_merchandise_top_data_to_item_info`
  FOREIGN KEY (`item_id`)
  REFERENCES `amiyadb`.`tbl_item_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
-----------------------------------------------余建明 2023/08/22 END--------------------------------------------


-----------------------------------------------余建明 2023/08/29 BEGIN--------------------------------------------
--库存列表新增过期时间
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD COLUMN `expire_date` DATETIME NULL AFTER `storage_racks_id`;
-----------------------------------------------余建明 2023/08/29 END--------------------------------------------
--------------------------------------------------------------------------以上已发布至线上
--新增助理薪资审核功能
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `compensation_check_state` INT NOT NULL DEFAULT 0 AFTER `hospital_id`,
ADD COLUMN `check_by` INT NULL AFTER `compensation_check_state`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_by`,
ADD COLUMN `check_remark` VARCHAR(1000) NULL AFTER `check_date`;
ADD COLUMN `check_belong_empid` INT NULL AFTER `check_remark`,
