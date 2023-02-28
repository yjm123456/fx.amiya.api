
-----------------------------余建明 2023/01/02 BEGIN -----------------------------
--内容平台成交情况新增信息服务费等数据
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `information_price` DECIMAL(12,2) NULL AFTER `check_price`,
ADD COLUMN `system_update_price` DECIMAL(12,2) NULL AFTER `information_price`;

--下单平台订单列表新增对账单id
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `reconciliation_documents_id` VARCHAR(50) NULL AFTER `deduct_money`;


--客户升单列表新增对账单id 
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `reconciliation_documents_id` VARCHAR(50) NULL AFTER `is_confirm_order`;

--医院板块新增是否在小程序展示列
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `is_share_in_miniprogram` BIT(1) NOT NULL AFTER `submit_state`;

--订单拉配置更新
ALTER TABLE `amiyadb`.`tbl_order_app_info` 
ADD COLUMN `shop_id` VARCHAR(45) NULL AFTER `id`,
ADD COLUMN `belong_liveanchor` VARCHAR(50)  NULL AFTER `refresh_token`;

--抖店订单列表新增归属主播id
ALTER TABLE `amiyadb`.`tbl_tiktok_order_info` 
ADD COLUMN `belong_live_anchor_id` VARCHAR(50) NULL AFTER `finish_date`;

INSERT INTO `amiyadb`.`tbl_miniprogram_auto_send_message` (`id`, `message`) VALUES ('1001', '当前没有客服在线，请给我们留言，我们会第一时间给你回复！');


-----------------------------余建明 2023/01/06 BEGIN -----------------------------



-----------------------------王健 2023/01/03 BEGIN -----------------------------


----抵用券添加对应的会员信息

ALTER TABLE `tbl_consumption_voucher`
	ADD COLUMN `is_member_voucher` BIT NOT NULL DEFAULT 0 AFTER `min_price`,
	ADD COLUMN `member_rank_code` VARCHAR(50) NULL DEFAULT '' AFTER `is_member_voucher`;

----礼品加入分类

ALTER TABLE `tbl_gift_info`
	ADD COLUMN `category_id` VARCHAR(50) NULL DEFAULT NULL AFTER `version`;




-----------------------------王健 2023/01/03 END -----------------------------


-----------------------------王健 2023/01/05 BEGIN -----------------------------

---内容平台订单表添加是否是重单可深度订单

ALTER TABLE `tbl_content_platform_order`
	ADD COLUMN `is_repeat_profundity_order` BIT NOT NULL DEFAULT 0 AFTER `commission_ratio`;

-----标签添加类别
ALTER TABLE `tbl_customer_tag_info`
	ADD COLUMN `tag_category` INT NULL DEFAULT NULL AFTER `tag_name`;

-----------------------------王健 2023/01/05 END -----------------------------









-----------------------------余建明 2023/01/13 BEGIN -----------------------------


--医院绑定客服列表新增医院id
ALTER TABLE `amiyadb`.`tbl_hospital_bind_customer_service` 
ADD COLUMN `hospital_id` INT NOT NULL AFTER `id`;


-----------------------------余建明 2023/01/13 END -----------------------------

-----------------------------王健 2023/01/13 Begin -----------------------------

--成交消息添加是否重单深度
ALTER TABLE `tbl_content_platform_order_deal_info`
	ADD COLUMN `is_repeat_profundity_order` BIT NOT NULL DEFAULT 0 AFTER `reconciliation_documents_id`;


-----------------------------王健 2023/01/13 END -----------------------------

-----------------------------余建明 2023/01/16 BEGIN -----------------------------
--对账单记录表新增归属客服与审核人
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `belong_live_anchor_account` INT  NULL AFTER `settle_date`,
ADD COLUMN `belong_emp_id` INT  NULL AFTER `belong_live_anchor_account`,
ADD COLUMN `create_by` INT NOT NULL AFTER `belong_emp_id`,
ADD COLUMN `account_type` BIT NOT NULL DEFAULT 0 AFTER `create_by`,
ADD COLUMN `account_price` DECIMAL(12,2) NOT NULL AFTER `account_type`;
-----------------------------余建明 2023/01/16 END -----------------------------

--对账单记录表新增归属客服与审核人主外键
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_recommand_document_settle_amiyaempinfo_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD CONSTRAINT `fk_recommand_document_settle_amiyaempinfo`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


-----------------------------余建明 2023/01/16 BEGIN -----------------------------
--审核记录加入订单金额与新老客
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `order_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `order_from`,
ADD COLUMN `is_oldcustomer` BIT(1) NOT NULL AFTER `order_price`;

-----------------------------余建明 2023/01/16 END -----------------------------

-----------------------------------------------余建明 2023/2/02 BEGIN--------------------------------------------
--票据表关联公司表
ALTER TABLE `amiyadb`.`tbl_bill` 
ADD INDEX `fk_bill_companyinfo_idx` (`collecting_company_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_bill` 
ADD CONSTRAINT `fk_bill_companyinfo`
  FOREIGN KEY (`collecting_company_id`)
  REFERENCES `amiyadb`.`tbl_company_base_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --票据表新增回款金额
  ALTER TABLE `amiyadb`.`tbl_bill` 
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `return_back_state`;

--对账单表加入是否开票以及对应票据id列
ALTER TABLE `amiyadb`.`tbl_reconciliation_documents` 
ADD COLUMN `is_create_bill` BIT(1) NOT NULL DEFAULT 0 AFTER `remark`,
ADD COLUMN `bill_id` VARCHAR(50) NULL AFTER `is_create_bill`;

--票据表更改主键类型
ALTER TABLE `amiyadb`.`tbl_bill` 
CHANGE COLUMN `id` `id` VARCHAR(50) NOT NULL ;

--账单表加入价格
ALTER TABLE `amiyadb`.`tbl_bill` 
ADD COLUMN `deal_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `hospital_id`,
ADD COLUMN `information_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `deal_price`,
ADD COLUMN `system_update_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `information_price`;


-----------------------------------------------余建明 2023/2/02 END--------------------------------------------




-----------------------------------------------王健 2023/2/07 BEGIN--------------------------------------------
---添加最近消费所属主播和微信号

ALTER TABLE `tbl_bind_customer_service`
	ADD COLUMN `new_live_anchor` VARCHAR(200) NULL DEFAULT NULL AFTER `all_order_count`,
	ADD COLUMN `new_wechat_no` VARCHAR(200) NULL DEFAULT NULL AFTER `new_live_anchor`;



--小程序类别添加图片

ALTER TABLE `tbl_goods_category`
	ADD COLUMN `category_img` VARCHAR(200) NULL DEFAULT NULL AFTER `sort`;


-----------------------------------------------王健 2023/2/07 END--------------------------------------------





-------------------------------------王健 2023/2/10 BEGIN----------------------------------------------

----内容平台订单加入是否开票和开票公司
ALTER TABLE `tbl_content_platform_order`
	ADD COLUMN `is_create_bill` BIT NOT NULL DEFAULT 0 AFTER `is_repeat_profundity_order`,
	ADD COLUMN `belong_company` VARCHAR(50) NULL DEFAULT NULL AFTER `is_create_bill`;



----内容平台成交信息订单加入是否开票和开票公司
ALTER TABLE `tbl_content_platform_order_deal_info`
	ADD COLUMN `is_create_bill` BIT NOT NULL DEFAULT 0 AFTER `is_repeat_profundity_order`,
	ADD COLUMN `belong_company` VARCHAR(50) NULL DEFAULT NULL AFTER `is_create_bill`;



----升单订单加入是否开票和开票公司
ALTER TABLE `tbl_customer_hospital_consume`
	ADD COLUMN `is_create_bill` BIT NOT NULL DEFAULT 0 AFTER `reconciliation_documents_id`,
	ADD COLUMN `belong_company` VARCHAR(50) NULL DEFAULT NULL AFTER `is_create_bill`;

----下单怕太订单加入是否开票和开票公司

ALTER TABLE `tbl_order_info`
	ADD COLUMN `is_create_bill` BIT NOT NULL DEFAULT 0 AFTER `reconciliation_documents_id`,
	ADD COLUMN `belong_company` VARCHAR(50) NULL DEFAULT NULL AFTER `is_create_bill`;
-------------------------------------王健 2023/2/10 END----------------------------------------------





-------------------------------------王健 2023/2/16 BEGIN-------------------------------------------


---积分加钱购相关

ALTER TABLE `tbl_order_trade`
	ADD COLUMN `trans_no` VARCHAR(50) NULL DEFAULT NULL AFTER `is_admin_add`;


ALTER TABLE `tbl_order_refund`
	ADD COLUMN `trans_no` VARCHAR(50) NULL DEFAULT NULL AFTER `delete_date`;

ALTER TABLE `tbl_goods_standards_price`
	ADD COLUMN `integral_amount` DECIMAL(10,2) NULL DEFAULT NULL AFTER `standards_img`;


--------------------------------------王健 2023/2/16 END--------------------------------------



-----------------------------------------------余建明 2023/2/16 BEGIN--------------------------------------------
--啊美雅员工板块加入企业微信id等参数
ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `user_id` VARCHAR(600) NULL AFTER `e_mail`,
ADD COLUMN `code` VARCHAR(600) NULL AFTER `user_id`,
ADD COLUMN `code_expire_date` DATETIME NULL AFTER `code`;
-----------------------------------------------余建明 2023/2/16 END--------------------------------------------


--职位管理列表加入是否可读取数据中心功能
ALTER TABLE `amiyadb`.`tbl_amiya_position_info` 
ADD COLUMN `read_datacenter` BIT(1) NOT NULL AFTER `department_id`;

-----------------------------------------------余建明 2023/2/19 BEGIN--------------------------------------------
--orderappInfo表更改归属主播字段类型
ALTER TABLE `amiyadb`.`tbl_order_app_info` 
CHANGE COLUMN `belong_liveanchor` `belong_liveanchor` INT NULL DEFAULT NULL ;

--成交情况表加入业绩类型
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `deal_performance_type` INT NOT NULL DEFAULT 0 AFTER `reconciliation_documents_id`;

--内容平台订单列表加入业绩类型
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `deal_performance_type` INT NOT NULL DEFAULT 0 AFTER `deal_date`;

-----------------------------------------------余建明 2023/2/22 END--------------------------------------------



------------------王健 2023-02-20 BEGIN--------------------------------------------

-----预约医院添加预约信息
ALTER TABLE `tbl_appointment_info`
	ADD COLUMN `appoint_area` VARCHAR(200) NOT NULL AFTER `hospital_id`;


-----商品信息添加排序

ALTER TABLE `tbl_goods_info`
	ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `is_optional`;

------------------王健 2023-02-20 END----------------------------------------------

-----------------------------------------------余建明 2023/2/25BEGIN--------------------------------------------
--对账单审核记录加入对账金额与业绩上传人员
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `recolication_price` DECIMAL(12,2) NULL AFTER `order_price`,
ADD COLUMN `create_emp_id` INT NULL AFTER `belong_emp_id`;
-----------------------------------------------余建明 2023/2/26 END--------------------------------------------
-----------------------------------------------余建明 2023/2/28 BEGIN--------------------------------------------
--主播基础信息加入是否为自播达人
ALTER TABLE `amiyadb`.`tbl_live_anchor_base_info` 
ADD COLUMN `is_self_live_anchor` BIT(1) NOT NULL AFTER `valid`;
-----------------------------------------------余建明 2023/2/28 BEGIN--------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------以上已发布至线上
