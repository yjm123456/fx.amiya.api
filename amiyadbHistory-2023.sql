---------------First Season Begin----

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
	`valid` BIT(1) NOT NULL ,
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



-----------------------------------------------余建明 2023/03/24 BEGIN--------------------------------------------

--新增录单申请列表
CREATE TABLE `amiyadb`.`tbl_content_pat_form_order_add_work` (
  `id` VARCHAR(50) NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `accept_by` INT UNSIGNED NOT NULL,
  `phone` VARCHAR(11) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `send_remark` VARCHAR(300) NULL,
  `belong_customer_service_id` INT NULL,
  `check_state` INT NOT NULL,
  `check_remark` VARCHAR(300) NULL,
  `check_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fkcontent_pat_form_order_add_work_createempInfo_idx` (`create_by` ASC) VISIBLE,
  INDEX `content_pat_form_order_add_work_acceptbyempinfo_idx` (`accept_by` ASC) VISIBLE,
  INDEX `content_pat_form_order_add_work_hospitalnfo_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fkcontent_pat_form_order_add_work_createempInfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `content_pat_form_order_add_work_acceptbyempinfo`
    FOREIGN KEY (`accept_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `content_pat_form_order_add_work_hospitalnfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
-----------------------------------------------余建明 2023/03/24 END--------------------------------------------
-----------------------------------------------王健 2023/03/31 BEGIN--------------------------------------------

--------微信视频号订单
CREATE TABLE `tbl_wechatvideo_order_info` (
	`id` VARCHAR(100) NOT NULL,
	`goods_name` VARCHAR(500) NOT NULL,
	`goods_id` VARCHAR(50) NOT NULL,
	`phone` VARCHAR(20) NULL DEFAULT NULL,
	`status_code` VARCHAR(50) NULL DEFAULT NULL,
	`actual_payment` DECIMAL(10,2) NULL DEFAULT NULL,
	`account_receivable` DECIMAL(10,2) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`thumb_pic_url` VARCHAR(500) NULL DEFAULT NULL,
	`buyer_nick` VARCHAR(225) NULL DEFAULT NULL,
	`order_type` BIGINT(19) NULL DEFAULT NULL,
	`quantity` INT(10) NULL DEFAULT NULL,
	`belong_emp_id` INT(10) NOT NULL,
	`check_state` INT(10) NULL DEFAULT NULL,
	`check_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_date` DECIMAL(10,2) NULL DEFAULT NULL,
	`settle_price` DECIMAL(10,2) NULL DEFAULT NULL,
	`check_by` INT(10) NULL DEFAULT NULL,
	`check_remark` VARCHAR(300) NULL DEFAULT NULL,
	`is_return_back_price` BIT(1) NOT NULL,
	`return_back_price` DECIMAL(12,2) NULL DEFAULT NULL,
	`return_back_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT(10) NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);



-----------------------------------------------王健 2023/03/31 END--------------------------------------------


---------------First Season End------
---------------Second Season Begin----

-----------------------------------------------余建明 2023/04/13 BEGIN--------------------------------------------

--新增客户预约日程表
CREATE TABLE `amiyadb`.`tbl_customer_appointment_schedule` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `appointment_type` INT  NOT NULL,  
  `customer_name` VARCHAR(100) NULL,
  `phone` VARCHAR(50) NULL,
  `appointment_date` DATETIME NOT NULL,
  `is_finish` BIT(1) NOT NULL,
  `important_type` INT NOT NULL,
  `remark` VARCHAR(300) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_customer_appointment_schedule_createempInfo_idx` (`create_by` ASC) VISIBLE,
  CONSTRAINT `fk_customer_appointment_schedule_createempInfo`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


	--新增通知动态板块功能数据表
	CREATE TABLE `amiyadb`.`tbl_message_notice` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `accept_by` INT UNSIGNED NOT NULL,
  `is_read` BIT(1) NOT NULL,
  `notice_type` INT NOT NULL,
  `notice_content` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tbl_message_notice_empinfo_idx` (`accept_by` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_message_notice_empinfo`
    FOREIGN KEY (`accept_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/04/13 END--------------------------------------------


----------------------------------------------王健 2023/04/20 BEGIN--------------------------------

------记录用户最近一次登录的appid
CREATE TABLE `tbl_user_lasttime_loginappid` (
	`id` VARCHAR(50) NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL,
	`user_id` VARCHAR(100) NOT NULL,
	`app_id` VARCHAR(50) NOT NULL,
	PRIMARY KEY (`id`) USING BTREE
);


--商品分类
CREATE TABLE `tbl_category_to_goods` (
	`id` VARCHAR(50) NOT NULL DEFAULT '',
	`goods_id` VARCHAR(50) NOT NULL DEFAULT '',
	`category_id` INT NOT NULL DEFAULT 0
);


---小程序信息

CREATE TABLE `tbl_miniprogram` (
	`id` VARCHAR(100) NOT NULL,
	`name` VARCHAR(100) NOT NULL,
	`appid` VARCHAR(100) NOT NULL,
	`is_main` BIT(1) NOT NULL,
	`belong_live_anchor_id` INT(10) NULL DEFAULT 0,
	`belong_appId` VARCHAR(100) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


----------------------------------------------王健 2023/04/20 END--------------------------------


-----------------------------------------------余建明 2023/05/13 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_content_platform_order_deal_details` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `goods_name` VARCHAR(300) NULL,
  `goods_spec` VARCHAR(45) NULL,
  `quantity` INT NOT NULL DEFAULT 0,
  `price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `content_platform_order_deal_id` VARCHAR(50) NULL,
  `content_platform_order_id` VARCHAR(50) NULL,
  `create_by` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2023/05/13 END--------------------------------------------


-----------------------------------------------王健 2023/05/17 BEGIN--------------------------------------

----健康值
CREATE TABLE `tbl_heath_value` (
	`id` VARCHAR(100) NOT NULL,
	`name` VARCHAR(200) NOT NULL,
	`code` VARCHAR(200) NOT NULL,
	`value` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);

-----------------------------------------------王健 2023/05/17 END--------------------------------------
-----------------------------------------------余建明 2023/05/23 BEGIN--------------------------------------------
--客户医院消费列表
CREATE TABLE `amiyadb`.`tbl_customer_hospital_deal_info` (
  `id` VARCHAR(50) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `type` INT NOT NULL,
  `customer_name` VARCHAR(45) NOT NULL,
  `customer_phone` VARCHAR(30) NOT NULL,
  `date` DATETIME NOT NULL,
  `total_amount` DECIMAL(12,2) NOT NULL,
  `consumption_type` INT NULL,
  `refund_type` INT NULL,
  `msg_id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_customer_hospital_deal_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_customer_hospital_deal_hospitalinfo`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


	--客户医院消费详情
	CREATE TABLE `amiyadb`.`tbl_customer_hospital_deal_details` (
  `id` VARCHAR(50) NOT NULL,
  `customer_hospital_deal_id` VARCHAR(50) NOT NULL,
  `item_name` VARCHAR(300) NULL,
  `item_standard` VARCHAR(400) NULL,
  `quantity` DECIMAL(12,2) NULL,
  `cash_amount` DECIMAL(12,2) NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `tbl_customer_hospital_deal_details_deal_info_idx` (`customer_hospital_deal_id` ASC) VISIBLE,
  CONSTRAINT `tbl_customer_hospital_deal_details_deal_info`
    FOREIGN KEY (`customer_hospital_deal_id`)
    REFERENCES `amiyadb`.`tbl_customer_hospital_deal_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2023/05/23 END--------------------------------------------



------------------------------------------王健 2023/06/14 BEGIN--------------------------------------


----微信支付信息
CREATE TABLE `tbl_wechat_payinfo` (
	`id` VARCHAR(50) NOT NULL ,
	`app_id` VARCHAR(50) NOT NULL,
	`app_secret` VARCHAR(50) NOT NULL,
	`partner_id` VARCHAR(50) NOT NULL,
	`partner_key` VARCHAR(50) NOT NULL,
	`enablesp` BIT(1) NOT NULL DEFAULT 0,
	`sub_app_id` VARCHAR(50) NOT NULL,
	`sub_mch_id` VARCHAR(50) NOT NULL,
	`remark` VARCHAR(200) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL
);

------------------------------------------王健 2023/06/14 END--------------------------------------



---------------Second Season End------
---------------Third Season Begin----


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
	`valid` BIT(1) NOT NULL,
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
	`valid` BIT(1) NOT NULL ,
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
	`valid` BIT(1) NOT NULL,
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
  CONSTRAINT `fk_to_live_replay_live_replay_interactionl_data`
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
-----------------------------------------------余建明 2023/09/20 BEGIN--------------------------------------------
--助理薪资账单表CREATE TABLE `amiyadb`.`tbl_customer_service_compensation` (
  `id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `create_by` INT UNSIGNED NOT NULL,
  `name` VARCHAR(100) NOT NULL,
  `belong_emp_id` INT UNSIGNED NOT NULL,
  `total_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
  `other_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
  `remark` VARCHAR(1000) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_customer_service_compensation_create_by_idx` (`create_by` ASC) VISIBLE,
  INDEX `fk_customer_service_compensation_belong_empid_idx` (`belong_emp_id` ASC) VISIBLE,
  CONSTRAINT `fk_customer_service_compensation_create_by`
    FOREIGN KEY (`create_by`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_customer_service_compensation_belong_empid`
    FOREIGN KEY (`belong_emp_id`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
-----------------------------------------------余建明 2023/09/20 END--------------------------------------------


--------------------------------------------王健 2023/09/18 START-------------------------------------------------


-------------医院合同
CREATE TABLE `tbl_hospital_contract` (
	`id` VARCHAR(50) NOT NULL,
	`hospital_id` INT(10) NOT NULL,
	`name` VARCHAR(500) NOT NULL,
	`contract_url` VARCHAR(500) NOT NULL,
	`start_date` DATETIME NULL DEFAULT NULL,
	`expire_date` DATETIME NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL DEFAULT '0',
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


--------------------------------------------王健 2023/09/18 END-------------------------------------------------


---------------Third Season End------
---------------Fourth Season Begin----
--------------------------------------------王健 2023/11/02 START-------------------------------------------------

---飞书应用证书

CREATE TABLE `tbl_feishu_app_info` (
	`id` VARCHAR(50) NOT NULL,
	`code` VARCHAR(100) NOT NULL,
	`app_id` VARCHAR(100) NOT NULL DEFAULT '',
	`app_secret` VARCHAR(100) NOT NULL DEFAULT '',
	`app_token` VARCHAR(100) NOT NULL DEFAULT '',
	`table_id` VARCHAR(100) NOT NULL DEFAULT '',
	`access_token` VARCHAR(100) NULL DEFAULT NULL,
	`expire_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT(10) NOT NULL,
	`remark` VARCHAR(100) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


---抖音短视频数据

CREATE TABLE `tbl_tiktok_short_video_data` (
	`id` VARCHAR(50) NOT NULL,
	`play_num` INT(10) NULL DEFAULT '0',
	`title` VARCHAR(200) NULL DEFAULT NULL,
	`like` INT(10) NULL DEFAULT '0',
	`video_id` VARCHAR(200) NULL DEFAULT NULL,
	`comments` INT(10) NULL DEFAULT '0',
	`belong_live_anchor_id` INT(10) NOT NULL DEFAULT '0',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`) 
);


--------------------------------------------王健 2023/11/02 END-------------------------------------------------


---------------Fourth Season End------


