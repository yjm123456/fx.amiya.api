---------------First Season Begin----

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


----------------------------------------------余建明2023/3/8 BEGIN-----------------------------------------------------


--啊美雅员工新增绑定主播基础账户id
ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `bind_base_live_anchor_id` VARCHAR(50) NULL AFTER `code_expire_date`;


----------------------------------------------余建明2023/3/8 END-----------------------------------------------------




----------------------------------------------王健 2023/3/11 BEGIN-----------------------------------------------------


------发票添加回款时间
ALTER TABLE `tbl_bill`
	ADD COLUMN `return_back_price_date` DATETIME NULL DEFAULT NULL AFTER `delete_date`;


----------------------------------------------王健 2023/3/11 BEGIN-----------------------------------------------------

----------------------------------------------余建明2023/3/15 BEGIN-----------------------------------------------------
--职位列表新增企业微信查看主播数据权限
ALTER TABLE `amiyadb`.`tbl_amiya_position_info` 
ADD COLUMN `read_live_anchor_data` BIT(1) NOT NULL AFTER `read_datacenter`;

----------------------------------------------余建明2023/3/15 END-----------------------------------------------------

----------------------------------------------王健2023/3/16 BEGIN-----------------------------------------------------


-----订单发货信息添加订单id
ALTER TABLE `tbl_send_goods_record`
	ADD COLUMN `order_id` VARCHAR(50) NULL DEFAULT NULL AFTER `express_id`;


----------------------------------------------王健2023/3/16 END-----------------------------------------------------


---------------------------------------王健2023/3/18 BEGIN-----------------------------------------------


----医院信息添加字段
ALTER TABLE `tbl_hospital_info`
	ADD COLUMN `send_order` INT NULL DEFAULT NULL AFTER `belong_company`,
	ADD COLUMN `new_customer_commission_ratio` DECIMAL(10,2) NULL DEFAULT NULL AFTER `send_order`,
	ADD COLUMN `old_customer_commission_ratio` DECIMAL(10,2) NULL DEFAULT NULL AFTER `new_customer_commission_ratio`,
	ADD COLUMN `repeat_order_rule` VARCHAR(1000) NULL DEFAULT NULL AFTER `old_customer_commission_ratio`,
	ADD COLUMN `year_service_fee` INT NULL DEFAULT NULL AFTER `repeat_order_rule`,
	ADD COLUMN `security_deposit` INT NULL DEFAULT NULL AFTER `year_service_fee`;


---医院添加简称,排序
ALTER TABLE `tbl_hospital_info`
	ADD COLUMN `simple_name` VARCHAR(100) NULL DEFAULT NULL AFTER `security_deposit`,
	ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `simple_name`;

----医院添加年服务费,保证金金额
ALTER TABLE `tbl_hospital_info`
	ADD COLUMN `year_service_money` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `sort`,
	ADD COLUMN `security_deposit_money` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `year_service_money`;

---操作日志添加来源
ALTER TABLE `tbl_system_operation_log`
	ADD COLUMN `source` INT NULL DEFAULT 0 AFTER `delete_date`;

---------------------------------------王健2023/3/18 END-----------------------------------------------

----------------------------------------------余建明2023/3/20 BEGIN-----------------------------------------------------
--城市新增排序功能
ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `province_id`;
----------------------------------------------余建明2023/3/20 END-----------------------------------------------------


---------------------------------------王健2023/3/21 BEGIN-----------------------------------------------

----美学设计报告添加城市
ALTER TABLE `tbl_aesthetics_design_report`
	ADD COLUMN `city` `city` VARCHAR(150) NULL DEFAULT NULL  AFTER `history_describe3`;



----美学设计标签添加图片方向
ALTER TABLE `tbl_aesthetics_design_report_tags`
	ADD COLUMN `direct_type` INT NOT NULL AFTER `tag_id`;


---- 美学设计添加医院id
ALTER TABLE `tbl_aesthetics_design`
	ADD COLUMN `hospital_id` INT NOT NULL AFTER `delete_date`;

----美学设计更改主键字段类型
ALTER TABLE `tbl_aesthetics_design`
	CHANGE COLUMN `id` `id` VARCHAR(50) NOT NULL;

----- 美学设计添加调整后的图片
ALTER TABLE `amiyadb`.`tbl_aesthetics_design` 
ADD COLUMN `front_picture` VARCHAR(500) NULL AFTER `hospital_id`,
ADD COLUMN `side_picture` VARCHAR(500) NULL AFTER `front_picture`;

---------------------------------------王健2023/3/21 END-----------------------------------------------

----------------------------------------------余建明2023/3/24 BEGIN-----------------------------------------------------
--内容平台订单新增是否为辅助订单功能
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_support_order` BIT(1) NOT NULL DEFAULT 0 AFTER `commission_ratio`,
ADD COLUMN `support_emp_id` INT NOT NULL DEFAULT 0 AFTER `is_support_order`;
----------------------------------------------余建明2023/3/24 END-----------------------------------------------------

----------------------------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



---------------First Season End------
---------------Second Season Begin----
-----------------------------------------------余建明 2023/04/03 BEGIN--------------------------------------------
--对账单列表新增发票编号
ALTER TABLE `amiyadb`.`tbl_reconciliation_documents` 
ADD COLUMN `bill_id2` VARCHAR(50) NULL AFTER `create_by`;

-----------------------------------------------余建明 2023/04/03 END--------------------------------------------


-----------------------------------------------王健 2023/04/03 BEGIN--------------------------------------------

----客户表添加小程序app_id
ALTER TABLE `tbl_customer_info`
	ADD COLUMN `app_id` VARCHAR(50) NULL DEFAULT NULL AFTER `phone`;
-----------------------------------------------王健 2023/04/03 END--------------------------------------------

-----------------------------------------------余建明 2023/04/11 BEGIN--------------------------------------------
--内容平台订单列表新增医院网咨与医院现场咨询人员名称登记
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `network_consulation_name` VARCHAR(45) NULL AFTER `send_date`,
ADD COLUMN `scene_consulation_name` VARCHAR(45) NULL AFTER `network_consulation_name`;
-----------------------------------------------余建明 2023/04/11 END--------------------------------------------


-----------------------------------------------余建明 2023/04/13 BEGIN--------------------------------------------
--小黄车订单列表新增指派人
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `assign_emp_id` INT NULL AFTER `is_send_order`;
ADD COLUMN `sub_phone` VARCHAR(45) NULL AFTER `phone`;
--同步小黄车订单列表创建人为指派人
update  amiyadb.tbl_shopping_cart_registration set assign_emp_id=create_by
-----------------------------------------------余建明 2023/04/13 END--------------------------------------------

-----------------------------------------------王健 2023/04/20 BEGIN--------------------------------------------

--轮播图添加归属小程序

ALTER TABLE `tbl_homepage_carousel_image`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `link_url`;


--商品添加归属小程序
ALTER TABLE `tbl_goods_info`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `sort`;


--商品添加是否热门
ALTER TABLE `tbl_goods_info`
	ADD COLUMN `ishot` BIT NOT NULL AFTER `appid`;

--商品分类添加归属小程序和是否热门
ALTER TABLE `tbl_goods_category`
	ADD COLUMN `appid` VARCHAR(100) NULL DEFAULT NULL AFTER `category_img`,
	ADD COLUMN `ishot` BIT NOT NULL AFTER `appid`;

---客户信息添加跳转appid
ALTER TABLE `tbl_customer_info`
	ADD COLUMN `assiste_app_id` VARCHAR(50) NULL DEFAULT NULL AFTER `app_id`;

----预约添加叫车地址
ALTER TABLE `tbl_appointment_info`
	ADD COLUMN `address` VARCHAR(500) NULL DEFAULT NULL AFTER `appoint_area`;



---商品分类添加是否是品牌分类
ALTER TABLE `tbl_goods_category`
	ADD COLUMN `isbrand` BIT NOT NULL AFTER `ishot`;

-----------------------------------------------王健 2023/04/20 END--------------------------------------------




-------------------------------------------------王健 2023/04/25 BEGIN---------------------------------------------


-----预约日程添加预约医院和接诊咨询
ALTER TABLE `tbl_customer_appointment_schedule`
	ADD COLUMN `appointment_hospital_id` INT NULL DEFAULT NULL AFTER `remark`,
	ADD COLUMN `consultation` VARCHAR(50) NULL DEFAULT NULL AFTER `appointment_hospital_id`;


-------------------------------------------------王健 2023/04/25 END---------------------------------------------


-----------------------------------------------余建明 2023/04/26 BEGIN--------------------------------------------

--直播前数据切换主外键-抖音
ALTER TABLE `amiyadb`.`tbl_beforeliving_tiktok_daily_target` 
DROP FOREIGN KEY `fk_tiktok_monthly_target`;
ALTER TABLE `amiyadb`.`tbl_beforeliving_tiktok_daily_target` 
ADD INDEX `fk_tiktok_monthly_target_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE,
DROP INDEX `fk_tiktok_monthly_target_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_beforeliving_tiktok_daily_target` 
ADD CONSTRAINT `fk_tiktok_monthly_target`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_before_living` (`id`);
  
--直播前数据切换主外键-小红书
  ALTER TABLE `amiyadb`.`tbl_beforeliving_xiaohongshu_daily_target` 
ADD INDEX `fk_xiaohongshu_monthlytarget_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_beforeliving_xiaohongshu_daily_target` 
ADD CONSTRAINT `fk_xiaohongshu_monthlytarget`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_before_living` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
--直播前数据切换主外键-知乎
  ALTER TABLE `amiyadb`.`tbl_beforeliving_zhihu_daily_target` 
DROP FOREIGN KEY `fk_zhihu_monthly_target`;
ALTER TABLE `amiyadb`.`tbl_beforeliving_zhihu_daily_target` 
ADD INDEX `fk_zhihu_monthly_target_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE,
DROP INDEX `fk_zhihu_monthly_target_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_beforeliving_zhihu_daily_target` 
ADD CONSTRAINT `fk_zhihu_monthly_target`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_before_living` (`id`);
  
--直播前数据切换主外键-微博
  ALTER TABLE `amiyadb`.`tbl_beforeliving_sina_weibo_daily_target` 
DROP FOREIGN KEY `fk_sina_weibo_monthly_target`;
ALTER TABLE `amiyadb`.`tbl_beforeliving_sina_weibo_daily_target` 
ADD INDEX `fk_sina_weibo_monthly_target_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE,
DROP INDEX `fk_sina_weibo_monthly_target_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_beforeliving_sina_weibo_daily_target` 
ADD CONSTRAINT `fk_sina_weibo_monthly_target`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_before_living` (`id`);
  
--直播前数据切换主外键-视频号
  ALTER TABLE `amiyadb`.`tbl_beforeliving_video_daily_target` 
DROP FOREIGN KEY `fk_video_monthly_target`;
ALTER TABLE `amiyadb`.`tbl_beforeliving_video_daily_target` 
ADD INDEX `fk_video_monthly_target_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE,
DROP INDEX `fk_video_monthly_target_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_beforeliving_video_daily_target` 
ADD CONSTRAINT `fk_video_monthly_target`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_before_living` (`id`);




--直播中日数据表切换主外键
ALTER TABLE `amiyadb`.`tbl_living_daily_target` 
ADD CONSTRAINT `fk_living_daily_target_livingmonthlytarget`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_living` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  
--直播后日数据表切换主外键
  ALTER TABLE `amiyadb`.`tbl_after_living_daily_target` 
DROP FOREIGN KEY `fk_after_living_monthly_target`;
ALTER TABLE `amiyadb`.`tbl_after_living_daily_target` 
ADD INDEX `fk_after_living_monthly_target_idx` (`live_anchor_monthly_target_id` ASC) VISIBLE,
DROP INDEX `fk_after_living_monthly_target_idx` ;
;
ALTER TABLE `amiyadb`.`tbl_after_living_daily_target` 
ADD CONSTRAINT `fk_after_living_monthly_target`
  FOREIGN KEY (`live_anchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target_after_living` (`id`);

  
-----------------------------------------------余建明 2023/04/26 END--------------------------------------------




-----------------------------------------王健  2023/05/04 BEGIN ------------------------------------------------

--预约日程添加指派主播
ALTER TABLE `tbl_customer_appointment_schedule`
	ADD COLUMN `assign_liveanchor_id` VARCHAR(50) NULL DEFAULT NULL AFTER `consultation`;

----成交情况添加消费类型
ALTER TABLE `tbl_content_platform_order_deal_info`
	ADD COLUMN `consumption_type` INT NULL DEFAULT NULL AFTER `belong_company`;
-----------------------------------------王健  2023/05/04 END ------------------------------------------------



-------------------------------------------王健 2023/05/10 BEGIN ----------------------------------------


----小黄车登记添加基础主播id,客户来源
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `base_liveanchor_id` VARCHAR(50) NULL DEFAULT NULL AFTER `emergency_level`,
	ADD COLUMN `source` INT NULL DEFAULT NULL AFTER `base_liveanchor_id`;

-------------------------------------------王健 2023/05/10 END ----------------------------------------

-----------------------------------------------余建明 2023/05/18 BEGIN--------------------------------------------
--成交详情板块数量改为decimal类型
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_details` 
CHANGE COLUMN `quantity` `quantity` DECIMAL(12,2) NOT NULL DEFAULT '0' ;
-----------------------------------------------余建明 2023/05/18 END--------------------------------------------



--------------------------------------------王健 2023/05/17 BEGIN----------------------------------------------------

---直播后日运营数据添加 有效业绩和潜在业绩
ALTER TABLE `tbl_after_living_daily_target`
	ADD COLUMN `effective_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `mini_van_bad_reviews`,
	ADD COLUMN `potential_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `effective_performance`;


---直播后月数据添加 有效业绩,累计有效业绩,目标完成率 潜在业绩,累计潜在业绩,目标完成率 
ALTER TABLE `tbl_liveanchor_monthly_target_after_living`
	ADD COLUMN `effective_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `mini_van_bad_reviews_complete_rate`,
	ADD COLUMN `cumulative_effective_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `effective_performance`,
	ADD COLUMN `effective_performance_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_effective_performance`,
	ADD COLUMN `potential_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `effective_performance_complete_rate`,
	ADD COLUMN `cumulative_potential_performance` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `potential_performance`,
	ADD COLUMN `potential_performance_completeRate` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_potential_performance`;


---直播中添加退卡量,gmv,去卡gmv以及相关累计量和目标完成率
ALTER TABLE `tbl_liveanchor_monthly_target_living`
	ADD COLUMN `living_refund_card` INT NOT NULL DEFAULT 0 AFTER `cargosettlementcommission_complete_rate`,
	ADD COLUMN `cumulative_living_refund_card` INT NOT NULL DEFAULT 0 AFTER `living_refund_card`,
	ADD COLUMN `living_refund_card_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `cumulative_living_refund_card`,
	ADD COLUMN `gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `living_refund_card_complete_rate`,
	ADD COLUMN `cumulative_gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `gmv`,
	ADD COLUMN `gmv_target_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `cumulative_gmv`,
	ADD COLUMN `eliminate_card_gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `gmv_target_complete_rate`,
	ADD COLUMN `cumulative_eliminate_card_gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `eliminate_card_gmv`,
	ADD COLUMN `eliminate_card_gmv_target_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `cumulative_eliminate_card_gmv`;

---直播中日运营数据添加退卡量,gmv,去卡gmv
ALTER TABLE `tbl_living_daily_target`
	ADD COLUMN `refund_card` INT NOT NULL DEFAULT 0 AFTER `record_date`,
	ADD COLUMN `gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `refund_card`,
	ADD COLUMN `eliminate_card_gmv` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `gmv`;



--------------------------------------------王健 2023/05/17 END----------------------------------------------------

-----------------------------------------------余建明 2023/05/24 BEGIN--------------------------------------------
--内容平台订单新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `settle_price`;

--内容平台订单成交情况新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `settle_price`;

--对账单审核记录新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NULL DEFAULT 0.00 AFTER `return_back_price`;
-----------------------------------------------余建明 2023/05/24 END--------------------------------------------



--客户预约日程新增客户照片
ALTER TABLE `amiyadb`.`tbl_customer_appointment_schedule` 
ADD COLUMN `customer_pic1` VARCHAR(300) NULL AFTER `assign_liveanchor_id`,
ADD COLUMN `customer_pic2` VARCHAR(300) NULL AFTER `customer_pic1`,
ADD COLUMN `customer_pic3` VARCHAR(300) NULL AFTER `customer_pic2`;

-----------------------------------------------余建明 2023/06/12 BEGIN--------------------------------------------
--录单申请新增申请类型
ALTER TABLE `amiyadb`.`tbl_content_pat_form_order_add_work` 
ADD COLUMN `add_work_type` INT NOT NULL AFTER `phone`;

update tbl_content_pat_form_order_add_work set add_work_type=1

-----------------------------------------------余建明 2023/06/29 END--------------------------------------------
--小黄车登记列表手机号加多位数
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
CHANGE COLUMN `phone` `phone` VARCHAR(20) NOT NULL ;
--录单申请列表手机号加多位数
ALTER TABLE `amiyadb`.`tbl_content_pat_form_order_add_work` 
CHANGE COLUMN `phone` `phone` VARCHAR(20) NOT NULL ;
-----------------------------------------------余建明 2023/06/29 END--------------------------------------------


---------------Second Season End------
---------------Third Season Begin----



---------------Third Season End------
---------------Fourth Season Begin----



---------------Fourth Season End------


