CREATE TABLE `amiyadb`.`tbl_goods_hospital_price` (
  `goods_id` VARCHAR(50) NOT NULL,
  `hospital_id` INT NOT NULL,
  `price` DECIMAL(10,2) NOT NULL DEFAULT 0.00);

  
-----------------------------------------------余建明 2021/08/10 BEGIN--------------------------------------------
  CREATE TABLE `amiyadb`.`tbl_order_write_off_info` (
  `id` VARCHAR(100) NOT NULL,
  `create_date` DATETIME NULL,
  `write_off_order_id` VARCHAR(100) NULL,
  `write_off_amount` INT NOT NULL,
  `order_least_amount` INT NOT NULL DEFAULT 0,
  `write_off_goods` VARCHAR(200) NULL,
  `write_off_hospitalid` VARCHAR(50) NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/08/10 END--------------------------------------------

--------------【1.2版本更新分支数据库更改】

-----------------------------------------------余建明 2021/09/04 BEGIN--------------------------------------------
--物流公司表
CREATE TABLE `amiyadb`.`tbl_amiya_express` (
  `id` VARCHAR(50) NOT NULL,
  `express_name` VARCHAR(45) NOT NULL,
  `express_code` VARCHAR(100) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));



-----------------------------------------------余建明 2021/09/04 END--------------------------------------------


-----------------------------------------------余建明 2021/09/07 BEGIN--------------------------------------------
  --医院科室表
  CREATE TABLE `amiyadb`.`tbl_amiya_hospital_department` (
  `id` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  `department_name` VARCHAR(100) NULL,
  `description` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));

  --商品需求表
  CREATE TABLE `amiyadb`.`tbl_amiya_goods_demand` (
  `id` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  `hospital_department_id` VARCHAR(50) NULL,
  `project_name` VARCHAR(200) NULL,
  `description` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));

-----------------------------------------------余建明 2021/09/07 END--------------------------------------------


-----------------------------------------------余建明 2021/09/22 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_province` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(20) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/09/22 END--------------------------------------------



-----------------------------------------------余建明 2021/09/23 BEGIN--------------------------------------------

CREATE TABLE `amiyadb`.`tbl_beauty_diary_tag_info` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));

  
CREATE TABLE `amiyadb`.`tbl_beauty_diary_manage` (
  `id` VARCHAR(50) NOT NULL,
  `cover_title` VARCHAR(300) NULL,
  `details_title` VARCHAR(300) NULL,
  `release_state` BIT(1) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `views` INT NOT NULL DEFAULT 0,
  `giving_likes` INT NOT NULL DEFAULT 0,
  `thumb_picture_url` VARCHAR(500) NULL,
  `video_url` VARCHAR(500) NULL,
  `details_description` VARCHAR(9999) NULL ,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_beauty_diary_banner_image` (
  `id` VARCHAR(50) NOT NULL,
  `beauty_diary_id` VARCHAR(50) NOT NULL,
  `pic_url` VARCHAR(500) NOT NULL,
  `display_index` TINYINT NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_beauty_diary_tag_detail` (
  `id` VARCHAR(50) NOT NULL,
  `beauty_diary_id` VARCHAR(50) NOT NULL,
  `tag_id` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_beautyDiaryTagDetail_tagid_beautyDiaryTagInfo_id_idx` (`tag_id` ASC) VISIBLE,
  INDEX `fx_beautyDiaryTagDetail_beautyDiaryid_beautyDiaryManage_id_idx` (`beauty_diary_id` ASC) VISIBLE,
  CONSTRAINT `fk_beautyDiaryTagDetail_tagid_beautyDiaryTagInfo_id`
    FOREIGN KEY (`tag_id`)
    REFERENCES `amiyadb`.`tbl_beauty_diary_tag_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fx_beautyDiaryTagDetail_beautyDiaryid_beautyDiaryManage_id`
    FOREIGN KEY (`beauty_diary_id`)
    REFERENCES `amiyadb`.`tbl_beauty_diary_manage` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-----------------------------------------------余建明 2021/09/23 END--------------------------------------------



-----------------------------------------------余建明 2021/11/10 BEGIN--------------------------------------------

CREATE TABLE `amiyadb`.`tbl_content_platform` (
  `id` VARCHAR(45)  NOT NULL,
  `content_platform_name` VARCHAR(45)  NOT NULL ,
  `valid` BIT NOT NULL,
  PRIMARY KEY (`id`));


  CREATE TABLE `amiyadb`.`tbl_content_plateform_order` (
  `id` VARCHAR(50) NOT NULL,
  `order_type` INT NULL,
  `content_plateform_id` VARCHAR(50) NULL,
  `live_anchor_id` INT NULL,
  `create_date` DATETIME NULL,
  `update_date` DATETIME NULL,
  `customer_name` VARCHAR(50) NULL,
  `phone` VARCHAR(20) NULL,
  `appointment_date` DATETIME NULL,
  `appointment_hospital_id` VARCHAR(50) NULL,
  `order_status` INT NULL,
  `deposit_amount` DECIMAL(10,2) NULL,
  `deal_amount` DECIMAL(10,2) NULL,
  `deal_picture_url` VARCHAR(200) NULL,
  `repeat_order_picture_url` VARCHAR(200) NULL,
  `undeal_reason` VARCHAR(200) NULL,
  `late_project_stage` VARCHAR(200) NULL,
  `consulting_content` VARCHAR(200) NULL,
  `remark` VARCHAR(200) NULL,
  PRIMARY KEY (`id`));


-----------------------------------------------余建明 2021/11/10 END--------------------------------------------






-----------------------------------------------侯宝平 2021/11/10 BEGIN--------------------------------------------;
--内容平台派单表
CREATE TABLE `amiyadb`.`tbl_content_platform_order_send`  (
  `id` int(32) UNSIGNED NOT NULL AUTO_INCREMENT,
  `content_platform_order_id` varchar(50) NOT NULL,
  `hospital_id` int(32) UNSIGNED NOT NULL,
  `sender` int(32) UNSIGNED NOT NULL,
  `send_date` datetime NOT NULL,
  `is_uncertain_date` bit NOT NULL COMMENT '是否未明确时间',
  `appointment_date` datetime NULL,
  `remark` varchar(500) NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_contentPlatformSendOrder_orderId_contentPlatformOrder_id` FOREIGN KEY (`content_platform_order_id`) REFERENCES `amiyadb`.`tbl_content_platform_order` (`id`),
  CONSTRAINT `fk_contentPlatformSendOrder_sender_amiyaEmployee_id` FOREIGN KEY (`sender`) REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
);
-----------------------------------------------侯宝平 2021/11/10 END--------------------------------------------;




-----------------------------------------------余建明 2021/12/4 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_employee_bind_liveanchor` (
  `id` VARCHAR(50) NOT NULL,
  `employee_id` INT NOT NULL,
  `live_anchor_id` INT NOT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/12/4 END--------------------------------------------;




-----------------------------------------------余建明 2021/12/9 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_notice_config` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(45) NULL,
  `state` BIT(1) NULL,
  PRIMARY KEY (`id`));

  INSERT INTO `amiyadb`.`tbl_notice_config` (`id`, `name`, `state`) VALUES ('4e4e9564-f6c3-47b6-a7da-e4518bab66cf', 'EMailNoticeConfig', b'0');

-----------------------------------------------余建明 2021/12/9 END--------------------------------------------;

-----------------------------------------------余建明 2021/12/24 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_content_platform_order_deal_info` (
  `id` NVARCHAR(50) NOT NULL,
  `content_platform_order_id`  NVARCHAR(50) NULL,
  `create_date` DATETIME NOT NULL,
  `is_to_hospital` BIT(1) NOT NULL DEFAULT 0,
  `is_deal` BIT(1) NOT NULL DEFAULT 0,
  `deal_picture` VARCHAR(200) NULL,
  `remark` VARCHAR(200) NULL,
  `price` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2021/12/24 END--------------------------------------------;



-----------------------------------------------余建明 2022/01/04 BEGIN--------------------------------------------


CREATE TABLE `amiyadb`.`tbl_liveanchor_monthly_target` (
  `id` VARCHAR(50) NOT NULL,
  `monthly_target_name` VARCHAR(200) NULL,
  `live_anchor_id` INT NOT NULL DEFAULT 0,
  `release_target` INT NOT NULL DEFAULT 0,
  `cumulative_release` INT NOT NULL DEFAULT 0,
  `release_complete_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `flow_investment_target` INT NOT NULL DEFAULT 0,
  `cumulative_flow_investment` INT NOT NULL DEFAULT 0,
  `flow_investment_complete_rate` DECIMAL(5,2) NULL DEFAULT 0.00,
  `add_wechat_target` INT NOT NULL DEFAULT 0,
  `cumulative_add_wechat` INT NOT NULL DEFAULT 0,
  `add_wechat_complete_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `send_order_target` INT NOT NULL DEFAULT 0,
  `cumulative_send_order` INT NOT NULL DEFAULT 0,
  `send_order_complete_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `visit_target` INT NOT NULL DEFAULT 0,
  `cumulative_visit` INT NOT NULL DEFAULT 0,
  `visit_complete_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `deal_target` INT NOT NULL DEFAULT 0,
  `cumulative_deal_target` INT NOT NULL DEFAULT 0,
  `deal_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `cumulative_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `performance_complete_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));


  CREATE TABLE `amiyadb`.`tbl_liveanchor_daily_target` (
  `id` VARCHAR(50) NOT NULL,
  `liveanchor_monthly_target_id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `operation_employee_id` INT NOT NULL DEFAULT 0,
  `network_consulting_employee_id` INT NOT NULL DEFAULT 0,
  `today_send_num` INT NOT NULL DEFAULT 0,
  `flow_investment_num` INT NOT NULL DEFAULT 0,
  `add_wechat_num` INT NOT NULL DEFAULT 0,
  `send_order_num` INT NOT NULL DEFAULT 0,
  `visit_num` INT NOT NULL DEFAULT 0,
  `deal_num` INT NOT NULL DEFAULT 0,
  `performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));

  
-----------------------------------------------余建明 2022/01/04 END--------------------------------------------;

-----------------------------------------------余建明 2022/01/17 BEGIN--------------------------------------------
CREATE TABLE `amiyadb`.`tbl_customer_integral_order_refund` (
  `id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NOT NULL,
  `customer_id` VARCHAR(50) NOT NULL,
  `refund_reason` VARCHAR(300) NULL,
  `create_date` DATETIME NOT NULL,
  `check_state` INT NOT NULL DEFAULT 0,
  `check_date` DATETIME  NULL,
  `chech_by` INT NOT NULL DEFAULT 0,
  `check_reason` VARCHAR(300) NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2022/01/17 END--------------------------------------------;


-----------------------------------------------余建明 2022/04/11 BEGIN--------------------------------------------;

CREATE TABLE `amiyadb`.`tbl_consumption_level` (
  `id` NVARCHAR(50) NOT NULL,
  `name` VARCHAR(45) NULL,
  `valid` BIT(1) NOT NULL DEFAULT 0,
  `min_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `max_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));

  --基础数据-医院环境表
  CREATE TABLE `amiyadb`.`tbl_hospital_environment` (
  `id` VARCHAR(50)  NOT NULL,
  `name` VARCHAR(45) NULL,
  `valid` BIT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`));

  --医院图片表
  CREATE TABLE `amiyadb`.`tbl_hospital_environment_picture` (
  `id` VARCHAR(50)  NOT NULL,
  `hospital_id` INT NULL,
  `hospital_environment_id` VARCHAR(50) NULL,
  `picture_url` VARCHAR(300) NULL,
  PRIMARY KEY (`id`));


-----------------------------------------------余建明 2022/04/11 END--------------------------------------------;


-----------------------------------------------余建明 2022/04/22 BEGIN--------------------------------------------;
CREATE TABLE `amiyadb`.`tbl_content_plat_form_customer_picture` (
  `id` VARCHAR(50) NOT NULL,
  `content_plat_form_id` VARCHAR(50) NOT NULL,
  `customer_picture` VARCHAR(300) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_content_plat_form_order_id_idx` (`content_plat_form_id` ASC) VISIBLE,
  CONSTRAINT `fk_content_plat_form_order_id`
    FOREIGN KEY (`content_plat_form_id`)
    REFERENCES `amiyadb`.`tbl_content_platform_order` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-----------------------------------------------余建明 2022/04/22 END--------------------------------------------;



-----------------------------------------------余建明 2022/05/05 BEGIN--------------------------------------------;
--审核图片存放表
CREATE TABLE `amiyadb`.`tbl_order_check_picture` (
  `id` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(50) NULL,
  `order_from` INT NULL,
  `picture_url` VARCHAR(300) NULL,
  PRIMARY KEY (`id`));
  
-----------------------------------------------余建明 2022/05/05 END--------------------------------------------;
-----------------------------------------------余建明 2022/06/01 BEGIN--------------------------------------------;

CREATE TABLE `amiyadb`.`tbl_shopping_cart_registration` (
  `id` VARCHAR(50) NOT NULL,
  `record_date` DATETIME NOT NULL,
  `content_plat_form_id` VARCHAR(50) NOT NULL,
  `live_anchor_id` INT NOT NULL,
  `live_anchor_wechat_no` VARCHAR(100) NULL,
  `customer_nick_name` VARCHAR(200) NULL,
  `phone` VARCHAR(11)NOT NULL,
  `price` DECIMAL(12,2)NOT NULL,
  `consultation_type` INT NOT NULL,
  `is_add_wechat` BIT(1) NOT NULL DEFAULT 0,
  `is_write_off` BIT(1) NOT NULL DEFAULT 0,
  `is_consultation` BIT(1) NOT NULL DEFAULT 0,
  `is_return_back_price` BIT(1) NOT NULL DEFAULT 0,
  `remark` VARCHAR(300) NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT NOT NULL,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_hospital_feedback` (
  `id` VARCHAR(50) NOT NULL,
  `title` VARCHAR(100) NULL,
  `content` VARCHAR(2000) NULL,
  `level` INT NOT NULL DEFAULT 0,
  `create_date` DATETIME NOT NULL,
  `create_hospital_id` INT NOT NULL,
  PRIMARY KEY (`id`));

  
-----------------------------------------------余建明 2022/06/01 END--------------------------------------------;



-----------------------------------------------余建明 2022/06/11 BEGIN--------------------------------------------;

CREATE TABLE `amiyadb`.`tbl_track_reported` (
  `id` VARCHAR(50) NOT NULL,
  `phone` VARCHAR(11) NOT NULL,
  `send_status` INT NOT NULL DEFAULT 0,
  `send_content` VARCHAR(500) NULL,
  `send_hospital_id` INT NOT NULL,
  `hospital_content` VARCHAR(500) NULL,
  `send_date` DATETIME NOT NULL,
  `send_by` INT NOT NULL,
  `track_record_id` INT NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2022/06/11 END--------------------------------------------;



-----------------------------------------------余建明 2022/06/24 BEGIN--------------------------------------------;
CREATE TABLE `amiyadb`.`tbl_amiya_warehouse` (
  `id` VARCHAR(50) NOT NULL,
  `unit` VARCHAR(45) NULL,
  `goods_name` VARCHAR(300) NOT NULL,
  `goods_source_id` VARCHAR(50) NOT NULL,
  `single_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `amount` INT NOT NULL DEFAULT 0,
  `total_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_amiya_warehouse_name_manage` (
  `id` VARCHAR(50) NOT NULL,
  `name` VARCHAR(100) NOT NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_inventory_list` (
  `id` VARCHAR(50) NOT NULL,
  `warehouse_id` VARCHAR(50) NOT NULL,
  `before_inventory_single_price` DECIMAL(12,2) NOT NULL,
  `before_inventory_num` INT NOT NULL,
  `before_inventory_all_price` DECIMAL(12,2) NOT NULL,
  `after_inventory_single_price` DECIMAL(12,2) NOT NULL,
  `after_inventory_num` INT NOT NULL,
  `after_inventory_all_price` DECIMAL(12,2) NOT NULL,
  `create_by` INT NOT NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_warehouse_info_idx` (`warehouse_id` ASC) VISIBLE,
  CONSTRAINT `fk_warehouse_info`
    FOREIGN KEY (`warehouse_id`)
    REFERENCES `amiyadb`.`tbl_amiya_warehouse` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

    CREATE TABLE `amiyadb`.`tbl_amiya_in_warehouse` (
  `id` VARCHAR(50) NOT NULL,
  `warehouse_id` VARCHAR(50) NOT NULL,
  `single_price` DECIMAL(12,2) NOT NULL,
  `num` INT NOT NULL,
  `all_price` DECIMAL(12,2) NOT NULL,
  `remark` VARCHAR(500) NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT NOT NULL,
  PRIMARY KEY (`id`));


  CREATE TABLE `amiyadb`.`tbl_amiya_out_warehouse` (
  `id` VARCHAR(50) NOT NULL,
  `warehouse_id` VARCHAR(45) NOT NULL,
  `single_price` DECIMAL(12,2) NOT NULL,
  `num` INT NOT NULL,
  `all_price` DECIMAL(12,2) NOT NULL,
  `remark` VARCHAR(500) NULL,
  `create_date` DATETIME NOT NULL,
  `create_by` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_warehouse_inf_idx` (`warehouse_id` ASC) VISIBLE,
  CONSTRAINT `fk_warehouse_inf`
    FOREIGN KEY (`warehouse_id`)
    REFERENCES `amiyadb`.`tbl_amiya_warehouse` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);



-----------------------------------------------余建明 2022/06/24 END--------------------------------------------;



-----------------------------------------------余建明 2022/07/19 BEGIN--------------------------------------------;

--主播微信号
CREATE TABLE `amiyadb`.`tbl_live_anchor_wechat_info` (
  `id` VARCHAR(50) NOT NULL,
  `live_anchor_id` INT UNSIGNED NOT NULL,
  `wechat_no` VARCHAR(100) NULL,
  `nick_name` VARCHAR(200) NULL,
  `remark` VARCHAR(300) NULL,
  `valid` BIT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_wechat_liveanchor_idx` (`live_anchor_id` ASC) VISIBLE,
  CONSTRAINT `fk_wechat_liveanchor`
    FOREIGN KEY (`live_anchor_id`)
    REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

    --主播介绍
    CREATE TABLE `amiyadb`.`tbl_live_anchor_base_info` (
  `id` VARCHAR(50) NOT NULL,
  `live_anchor_name` VARCHAR(100) NULL,
  `thumb_picture` VARCHAR(300) NULL,
  `nick_name` VARCHAR(45) NULL,
  `individuality_signature` VARCHAR(200) NULL,
  `description` VARCHAR(400) NULL,
  `detail_picture` VARCHAR(300) NULL,
  `is_main` INT NULL, 
  `valid` BIT NOT NULL ,
  PRIMARY KEY (`id`));

  --医院订单/客户对接基础表

  CREATE TABLE `amiyadb`.`tbl_docking_hospital_customer_info` (
  `id` VARCHAR(50) NOT NULL,
  `app_key` VARCHAR(100) NOT NULL,
  `app_secret` VARCHAR(5000) NOT NULL,
  `token` VARCHAR(5000) NULL,
  `authorize_date` DATETIME NULL,
  `expire_date` DATETIME NULL,
  `refresh_token` VARCHAR(3000) NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `base_url` VARCHAR(500) NULL,
  `token_url` VARCHAR(500) NULL,
  `get_customer_url` VARCHAR(500) NULL ,
  `get_customer_order_url` VARCHAR(500) NULL,
  `get_order_url` VARCHAR(500) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_docking_hospital_user_info_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_docking_hospital_user_info`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

    --回访模板基础表

    CREATE TABLE `amiyadb`.`tbl_track_type_theme_model` (
  `id` VARCHAR(50) NOT NULL,
  `track_type_id` INT UNSIGNED NOT NULL,
  `track_theme_id` INT UNSIGNED NOT NULL,
  `days_later` INT NOT NULL,
  `track_plan` VARCHAR(100) NULL,
  `create_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_track_type_info_idx` (`track_type_id` ASC) VISIBLE,
  INDEX `fk_track_theme_info_idx` (`track_theme_id` ASC) VISIBLE,
  CONSTRAINT `fk_track_type_info`
    FOREIGN KEY (`track_type_id`)
    REFERENCES `amiyadb`.`tbl_track_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_track_theme_info`
    FOREIGN KEY (`track_theme_id`)
    REFERENCES `amiyadb`.`tbl_track_theme` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-----------------------------------------------余建明 2022/07/19END--------------------------------------------;


-----------------------------------------------王健 2022/07/26BEGIN--------------------------------------------;


--抖店订单表
CREATE TABLE `tbl_tiktok_order_info` (
  `id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `goods_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `goods_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `appointment_hospital` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `final_consumption_hospital` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `actual_payment` decimal(10,2) DEFAULT NULL,
  `account_receivable` decimal(10,2) DEFAULT NULL,
  `status_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `thumb_pic_url` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `update_date` datetime DEFAULT NULL,
  `write_off_date` datetime DEFAULT NULL,
  `buyer_nick` varchar(225) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `app_type` tinyint NOT NULL COMMENT '下单平台（0=天猫，1=京东，2=阿美雅）',
  `is_appointment` bit(1) NOT NULL,
  `order_type` bigint DEFAULT NULL COMMENT '订单类型（0=虚拟订单，1=实物订单）',
  `order_nature` tinyint NOT NULL DEFAULT '0',
  `quantity` int unsigned DEFAULT NULL COMMENT '商品数量',
  `integration_quantity` decimal(18,2) DEFAULT NULL COMMENT '抵扣积分',
  `exchange_type` tinyint DEFAULT NULL COMMENT '交易类型（0=积分）',
  `trade_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '交易编号',
  `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '简介',
  `Standard` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '规格',
  `Parts` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT '部位',
  `write_off_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `already_write_off_amount` int NOT NULL DEFAULT '0',
  `live_anchor_id` int NOT NULL DEFAULT '0',
  `belong_emp_id` int NOT NULL DEFAULT '0',
  `check_state` int NOT NULL DEFAULT '0',
  `check_price` decimal(10,2) DEFAULT '0.00',
  `settle_price` decimal(10,2) DEFAULT '0.00',
  `check_by` int DEFAULT NULL,
  `check_remark` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `check_date` datetime DEFAULT NULL,
  `is_return_back_price` bit(1) NOT NULL,
  `return_back_price` decimal(12,2) DEFAULT NULL,
  `return_back_date` datetime DEFAULT NULL,
  `tiktok_user_id` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_tiktokOrderInfo_tradeId_orderTrade_tradeId` (`trade_id`) USING BTREE,
  KEY `fk_tiktokOrderInfo_tiktokUserInfoId_tiktokUserInfo_id` (`tiktok_user_id`) USING BTREE,
  CONSTRAINT `fk_tiktokOrderInfo_tiktokuserinfoid_tiktokUserInfoId_id` FOREIGN KEY (`tiktok_user_id`) REFERENCES `tbl_tiktok_userinfo` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_tiktokOrderInfo_tradeId_orderTrade_tradeId` FOREIGN KEY (`trade_id`) REFERENCES `tbl_order_trade` (`trade_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC

--抖店用户表

CREATE TABLE `tbl_tiktok_userinfo` (
  `id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `cipher_name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cipher_phone` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC


-----------------------------------------------王健 2022/07/26END--------------------------------------------;


-----------------------------------------------余建明 2022/07/11 BEGIN--------------------------------------------;
--小程序购物车
CREATE TABLE `amiyadb`.`tbl_goods_shopcar` (
  `id` VARCHAR(50) NOT NULL,
  `customer_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `goods_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `num` INT NOT NULL DEFAULT 0,
  `status` INT NOT NULL DEFAULT 1,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_goods_shop_car_shop_info_idx` (`goods_id` ASC) VISIBLE,
  CONSTRAINT `fk_goods_shop_car_customer_info`
    FOREIGN KEY (`customer_id`)
    REFERENCES `amiyadb`.`tbl_customer_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_goods_shop_car_shop_info`
    FOREIGN KEY (`goods_id`)
    REFERENCES `amiyadb`.`tbl_goods_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
-----------------------------------------------余建明 2022/07/11 END--------------------------------------------;



-----------------------------------------------余建明 2022/09/20 BEGIN--------------------------------------------;
--拍剪组工作数据填写
CREATE TABLE `amiyadb`.`tbl_shooting_and_clip` (
  `id` VARCHAR(50) NOT NULL,
  `shooting_empid` INT UNSIGNED NOT NULL,
  `clip_empid` INT UNSIGNED NOT NULL,
  `live_anchor_id` INT UNSIGNED NOT NULL,
  `title` VARCHAR(1000) NULL,
  `create_date` DATETIME NOT NULL,
  `record_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_shooting_empid_idx` (`shooting_empid` ASC) VISIBLE,
  INDEX `fk_clip_empid_idx` (`clip_empid` ASC) VISIBLE,
  INDEX `fk_live_anchor_idx` (`live_anchor_id` ASC) VISIBLE,
  CONSTRAINT `fk_shooting_empid`
    FOREIGN KEY (`shooting_empid`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_clip_empid`
    FOREIGN KEY (`clip_empid`)
    REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_shootingandclip_live_anchor`
    FOREIGN KEY (`live_anchor_id`)
    REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
-----------------------------------------------余建明 2022/09/20 END--------------------------------------------;
---抵用券
CREATE TABLE `tbl_consumption_voucher` (
  `id` varchar(100) NOT NULL,
  `consumption_voucher_code` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `deduct_money` decimal(10,2) DEFAULT '0.00',
  `is_specify_product` bit(1) NOT NULL DEFAULT b'0',
  `is_accumulate` bit(1) NOT NULL DEFAULT b'0',
  `is_share` bit(1) NOT NULL DEFAULT b'0',
  `effective_time` bigint DEFAULT '0',
  `type` int NOT NULL DEFAULT '0',
  `expire_date` datetime DEFAULT NULL,
  `is_valid` bit(1) NOT NULL,
  `create_date` datetime NOT NULL,
  `update_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


-----------------------------------------------余建明 2022/09/07 BEGIN--------------------------------------------;
CREATE TABLE `amiyadb`.`goods_member_rank_price` (
  `id` VARCHAR(50) NOT NULL,
  `goods_id` VARCHAR(50) NOT NULL,
  `member_rank_id` INT NOT NULL,
  `price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2022/09/07 END--------------------------------------------;



-----------------------------------------------王健 2022/09/09 BEGIN--------------------------------------------;
--商品可使用抵用券
 CREATE TABLE `tbl_goods_consumption_voucher` (
  `id` varchar(100) NOT NULL,
  `goods_id` varchar(100) NOT NULL,
  `consumption_voucher_id` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

-----------------------------------------------王健 2022/09/09 END--------------------------------------------;



--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



































------------------------------------------------------------------------------------------------------小程序---------------------------------------------------------------------------



-----------------------------------------------王健 2022/08/22 START--------------------------------------------










--用户拥有的抵用券
CREATE TABLE `tbl_customer_consumption_voucher` (
  `id` varchar(100) NOT NULL,
  `customer_id` varchar(100) NOT NULL,
  `consumption_voucher_id` varchar(100) NOT NULL,
  `is_used` bit(1) NOT NULL DEFAULT b'0',
  `expire_date` datetime DEFAULT NULL,
  `is_expire` bit(1) NOT NULL,
  `create_date` datetime NOT NULL,
  `use_date` datetime DEFAULT NULL,
  `source` int NOT NULL DEFAULT '0',
  `share_by` varchar(100) DEFAULT NULL,
  `write_of_code` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;





--用户成长值账号
CREATE TABLE `tbl_growth_points_account` (
  `customer_id` varchar(100) NOT NULL,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;





--用户成长值记录
CREATE TABLE `tbl_growth_points_record` (
  `id` varchar(100) NOT NULL,
  `quantity` decimal(10,2) NOT NULL DEFAULT '0.00',
  `type` int NOT NULL DEFAULT '0',
  `customer_id` varchar(100) NOT NULL,
  `order_id` varchar(100) DEFAULT NULL,
  `create_date` datetime NOT NULL,
  `expire_date` datetime DEFAULT NULL,
  `is_expire` bit(1) NOT NULL DEFAULT b'0',
  `account_balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


--用户余额账号表
CREATE TABLE `tbl_customer_balance_account` (
  `customer_id` varchar(100) NOT NULL,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--用户充值记录
CREATE TABLE `tbl_customer_balance_recharge_record` (
  `id` varchar(100) NOT NULL,
  `customer_id` varchar(100) NOT NULL,
  `exchage_type` int NOT NULL DEFAULT '0',
  `recharge_amount` decimal(10,2) NOT NULL DEFAULT '0.00',
  `order_id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `status` int NOT NULL DEFAULT '0',
  `recharge_date` datetime NOT NULL,
  `balance` decimal(10,2) NOT NULL,
  `complete_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `order_id` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


--用户余额
CREATE TABLE `tbl_customer_balance_use_record` (
  `id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `amount` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `order_id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  `use_type` int NOT NULL DEFAULT '0',
  `customer_id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


----储值赠送规则
CREATE TABLE `tbl_recharge_reward_rule` (
  `id` varchar(100) NOT NULL,
  `min_amount` decimal(10,2) NOT NULL DEFAULT '0.00',
  `give_integration` decimal(10,2) NOT NULL DEFAULT '0.00',
  `give_money` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


----充值金额
CREATE TABLE `tbl_recharge_amount` (
  `id` varchar(100) NOT NULL,
  `amount` decimal(10,2) NOT NULL DEFAULT '0.00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
;


----成长值获取规则
CREATE TABLE `tbl_growth_points_rule` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `reward_quantity` decimal(10,2) NOT NULL DEFAULT '0.00',
  `task_code` varchar(100) NOT NULL,
  `type` int NOT NULL DEFAULT '0',
  `reward_quantity_percent` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

-----------------------------------------------王健 2022/08/22 END--------------------------------------------




 



 -----------------------------------------------王健 2022/09/27 BEGIN--------------------------------------------

 --机构运营指标

 CREATE TABLE `tbl_hospital_operational_indicator` (
  `id` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `describe` varchar(500) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `excellent_hospital` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `submit_status` bit(1) NOT NULL,
  `remark_status` bit(1) NOT NULL,
  `create_date` datetime NOT NULL,
  `update_time` datetime DEFAULT NULL,
  `valid` int NOT NULL,
  `delete_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC



--运营指标派发医院
CREATE TABLE `tbl_indicator_send_hospital` (
  `id` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `indicator_id` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8_general_ci NOT NULL,
  `hospital_id` int unsigned NOT NULL,
  `submit_status` bit(1) NOT NULL,
  `remark_status` bit(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_indicatorsendhosiptal _hospital_id_hospitalinfo_id` (`hospital_id`) USING BTREE,
  KEY `fk_indicatorsendhosiptal _indicator_id_hospitaloperational_id` (`indicator_id`) USING BTREE,
  CONSTRAINT `fk_indicatorsendhosiptal _hospital_id_hospitalinfo_id` FOREIGN KEY (`hospital_id`) REFERENCES `tbl_hospital_info` (`id`),
  CONSTRAINT `fk_indicatorsendhosiptal _indicator_id_hospitaloperational_id` FOREIGN KEY (`indicator_id`) REFERENCES `tbl_hospital_operational_indicator` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC


-----------------------------------------------王健 2022/09/27 END--------------------------------------------

 -----------------------------------------------余建明 2022/09/27 BEGIN--------------------------------------------

 CREATE TABLE `amiyadb`.`tbl_great_hospital_operation_health` (
  `id` VARCHAR(50) NOT NULL,
  `indicator_id` VARCHAR(100) NOT NULL,
  `hospital_id` INT UNSIGNED NOT NULL,
  `create_date` DATETIME NOT NULL,
  `update_date` DATETIME NULL,
  `valid` BIT(1) NOT NULL,
  `delete_date` DATETIME NULL,
  `last_new_customer_visit_rate` DECIMAL(12,2) NOT NULL,
  `this_new_customer_visit_rate` DECIMAL(12,2) NOT NULL,
  `new_customer_visit_chain_ratio` DECIMAL(12,2) NOT NULL,
  `last_new_customer_deal_rate` DECIMAL(12,2) NOT NULL,
  `this_new_customer_deal_rate` DECIMAL(12,2) NOT NULL,
  `new_customer_deal_chain_ratio` DECIMAL(12,2) NOT NULL,
  `last_new_customer_unit_price` DECIMAL(12,2) NOT NULL,
  `this_new_customer_unit_price` DECIMAL(12,2) NOT NULL,
  `new_customer_unit_price_chain_ratio` DECIMAL(12,2) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_hospital_info_id_idx` (`hospital_id` ASC) VISIBLE,
  CONSTRAINT `fk_hospital_info_id`
    FOREIGN KEY (`hospital_id`)
    REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);



-----------------------------------------------余建明 2022/09/27 END--------------------------------------------





































































  --测试地址发布

-----------------------------------------------余建明 2022/04/29 BEGIN--------------------------------------------;
CREATE TABLE `amiyadb`.`tbl_hospital_brand_apply` (
  `id` VARCHAR(50) NOT NULL,
  `hospital_name` VARCHAR(100) NULL,
  `goods_url` VARCHAR(300) NULL,
  `goods_id` VARCHAR(12) NULL,
  PRIMARY KEY (`id`));

  CREATE TABLE `amiyadb`.`tbl_tmall_goods_sku` (
  `id` VARCHAR(50) NOT NULL,
  `goods_id` VARCHAR(12) NULL,
  `sku_name` VARCHAR(300) NULL,
  `price` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));

-----------------------------------------------余建明 2022/04/29 END--------------------------------------------;














--------------------暂时不用





  --商学院运营报表
CREATE TABLE `amiyadb`.`tbl_business_college_monthly_target` (
  `id` VARCHAR(50) NOT NULL,
  `year` INT NOT NULL,
  `month` INT NOT NULL,
  `monthly_target_name` VARCHAR(300) NULL,
  `private_domain_add_wechat_target` INT NOT NULL DEFAULT 0,
  `cumulative_private_domain_add_wechat` INT NOT NULL DEFAULT 0,
  `private_domain_add_wechat_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `business_college_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `cumulative_business_college_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `business_college_performance_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `we_media_release_target` INT NOT NULL DEFAULT 0,
  `cumulative_we_media_release` INT NOT NULL DEFAULT 0,
  `we_media_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `add_wechat_target` INT NOT NULL DEFAULT 0,
  `cumulative_add_wechat` INT NOT NULL DEFAULT 0,
  `add_wechat_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `deal_target` INT NOT NULL DEFAULT 0,
  `cumulative_deal_target` INT NOT NULL DEFAULT 0,
  `deal_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `cumulative_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `performance_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));


  CREATE TABLE `amiyadb`.`tbl_business_college_dialy_target` (
  `id` VARCHAR(50) NOT NULL,
  `business_college_monthly_target_id` VARCHAR(50) NOT NULL,
  `create_date` DATETIME NOT NULL,
  `record_date` DATETIME NULL,
  `create_by` INT NOT NULL,
  `today_private_domain_add_wechat` INT NOT NULL DEFAULT 0,
  `today_business_college_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `today_we_media_release` INT NOT NULL DEFAULT 0,
  `today_add_wechat` INT NOT NULL DEFAULT 0,
  `today_deal` INT NOT NULL DEFAULT 0,
  `today_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`id`));


-----------------------------------------------余建明 2022/04/20 BEGIN--------------------------------------------;
CREATE TABLE `amiyadb`.`tbl_hospital_financial_statement` (
  `id` VARCHAR(50) NOT NULL,
  `year` INT NULL,
  `month` INT NULL,
  `platform` INT NULL,
  `order_id` VARCHAR(50) NULL,
  `order_status` INT NULL,
  `buyer_nick` VARCHAR(60) NULL,
  `phone` VARCHAR(11) NULL,
  `order_create_time` DATETIME NULL,
  `write_off_time` DATETIME NULL,
  `goods_name` VARCHAR(200) NULL,
  `actual_payment` DECIMAL(12,2) NULL,
  `quantity` INT NULL,
  `send_order_price` DECIMAL(12,2) NULL,
  `settle_commission` DECIMAL(12,2) NULL,
  `settle_state` INT NOT NULL DEFAULT 0,
  `hospital_submit_price` DECIMAL(12,2) NULL,
  PRIMARY KEY (`id`));
-----------------------------------------------余建明 2022/04/20 END--------------------------------------------;

CREATE TABLE `amiyadb`.`tbl_order_info_cold_data` (
  `id` VARCHAR(100) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `goods_name` VARCHAR(100) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `goods_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `phone` VARCHAR(20) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL,
  `appointment_hospital` VARCHAR(100) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL,
  `final_consumption_hospital` VARCHAR(100) NULL DEFAULT NULL,
  `actual_payment` DECIMAL(10,2) NULL DEFAULT NULL,
  `account_receivable` DECIMAL(10,2) NULL DEFAULT NULL,
  `status_code` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL,
  `thumb_pic_url` VARCHAR(500) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL,
  `create_date` DATETIME NULL DEFAULT NULL,
  `update_date` DATETIME NULL DEFAULT NULL,
  `write_off_date` DATETIME NULL DEFAULT NULL,
  `buyer_nick` VARCHAR(225) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL,
  `app_type` TINYINT NOT NULL COMMENT '下单平台（0=天猫，1=京东，2=阿美雅）',
  `is_appointment` BIT(1) NOT NULL,
  `order_type` TINYINT NULL DEFAULT NULL COMMENT '订单类型（0=虚拟订单，1=实物订单）',
  `order_nature` TINYINT NOT NULL DEFAULT '0',
  `quantity` INT UNSIGNED NULL DEFAULT NULL COMMENT '商品数量',
  `integration_quantity` DECIMAL(18,2) NULL DEFAULT NULL COMMENT '抵扣积分',
  `exchange_type` TINYINT NULL DEFAULT NULL COMMENT '交易类型（0=积分）',
  `trade_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NULL DEFAULT NULL COMMENT '交易编号',
  `Description` VARCHAR(200) NULL DEFAULT NULL COMMENT '简介',
  `Standard` VARCHAR(100) NULL DEFAULT NULL COMMENT '规格',
  `Parts` VARCHAR(100) NULL DEFAULT NULL COMMENT '部位',
  `write_off_code` VARCHAR(50) NULL DEFAULT NULL,
  `already_write_off_amount` INT NOT NULL DEFAULT '0',
  INDEX `fk_orderInfo_tradeId_orderTrade_tradeId` (`trade_id` ASC) INVISIBLE,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


insert into amiyadb.tbl_order_info_cold_data select * from amiyadb.tbl_order_info  --备份订单表




