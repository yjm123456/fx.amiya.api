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


--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上



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

--内容平台订单新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `settle_price`;

--内容平台订单成交情况新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `settle_price`;

--对账单审核记录新增审核客服业绩金额
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `customer_service_settle_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `return_back_price`;

