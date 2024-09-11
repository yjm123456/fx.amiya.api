

------------------------------------王健 2024/7/1 BEGIN--------------------------------------


---内容平台订单添加归属部门
ALTER TABLE `tbl_content_platform_order`
	ADD COLUMN `belong_channel` INT NOT NULL DEFAULT 0 AFTER `customer_type`;

------------------------------------王健 2024/7/1 END--------------------------------------


------------------------------------王健 2024/7/16 BEGIN--------------------------------------

---直播后日运营数据添加线索量
ALTER TABLE `tbl_after_living_daily_target`
	ADD COLUMN `clues` INT NOT NULL DEFAULT 0 AFTER `distribute_consulation`;

---直播后月运营数据添加线索量,累计线索量,线索量目标完成率
ALTER TABLE `tbl_liveanchor_monthly_target_after_living`
	ADD COLUMN `clues_target` INT NOT NULL DEFAULT 0 AFTER `distribute_consulation_completeRate`,
	ADD COLUMN `cumulative_clues` INT NOT NULL DEFAULT 0 AFTER `clues_target`,
	ADD COLUMN `clues_complete_rate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `cumulative_clues`;

------------------------------------王健 2024/7/16 END--------------------------------------

------------------------------------王健 2024/7/23 BEGIN--------------------------------------

--内容平台订单添加次派咨询内容

ALTER TABLE `tbl_content_platform_order`
	ADD COLUMN `consulting_content2` VARCHAR(2000) NULL DEFAULT NULL AFTER `belong_channel`;


------------------------------------王健 2024/7/23 END--------------------------------------

------------------------------------余建明 2024/7/23 BEGIN--------------------------------------
--粉丝见面会详情表新增未成交数据和下次邀约数据
ALTER TABLE `amiyadb`.`tbl_fans_meeting_details` 
ADD COLUMN `un_deal_reason` VARCHAR(500) NULL AFTER `cumulative_deal_price`,
ADD COLUMN `fans_meeting_project` VARCHAR(500) NULL AFTER `un_deal_reason`,
ADD COLUMN `follow_up_content` VARCHAR(500) NULL AFTER `fans_meeting_project`,
ADD COLUMN `next_appointment_date` DATETIME NULL AFTER `follow_up_content`,
ADD COLUMN `is_need_hospital_help` BIT(1) NOT NULL AFTER `next_appointment_date`;
------------------------------------余建明 2024/7/23 END--------------------------------------
------------------------------------王健 2024/7/30 BEGIN--------------------------------------

--直播中月目标添加 线索量,累计线索量,线索量目标完成率
ALTER TABLE `tbl_liveanchor_monthly_target_living`
	ADD COLUMN `clues_target` INT NOT NULL DEFAULT 0 AFTER `cumulative_refund_gmv`,
	ADD COLUMN `clues_target_completerate` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `clues_target`,
	ADD COLUMN `cumulative_clues` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `clues_target_completerate`;


--直播中日运营数据添加 今日线索量
ALTER TABLE `tbl_living_daily_target`
	ADD COLUMN `clues` INT NOT NULL DEFAULT 0 AFTER `weixin_dou`;


------------------------------------王健 2024/7/30 END--------------------------------------


------------------------------------王健 2024/7/31 BEGIN--------------------------------------

--带货商品添加讲解时间,和首次上架时间
ALTER TABLE `tbl_item_info`
	ADD COLUMN `explan_times` INT NULL DEFAULT 0 AFTER `remark`,
	ADD COLUMN `firsttime_on_sell` DATETIME NULL DEFAULT NULL AFTER `explan_times`;

--派单信息添加订单状态
ALTER TABLE `tbl_content_platform_order_send`
	ADD COLUMN `order_status` INT NOT NULL DEFAULT 0 AFTER `is_main_hospital`;

--派单信息添加是否重单可深度
ALTER TABLE `tbl_content_platform_order_send`
	ADD COLUMN `is_repeat_profundity_order` BIT NOT NULL DEFAULT 0 AFTER `order_status`;

------------------------------------王健 2024/7/31 BEGIN--------------------------------------

------------------------------------王健 2024/8/5 BEGIN--------------------------------------

--带货商品字段约束修改

ALTER TABLE `tbl_item_info`
	CHANGE COLUMN `brand_id` `brand_id` VARCHAR(50) NULL DEFAULT NULL  AFTER `other_app_item_id`,
	CHANGE COLUMN `category_id` `category_id` VARCHAR(50) NULL DEFAULT NULL  AFTER `brand_id`,
	CHANGE COLUMN `item_details_id` `item_details_id` VARCHAR(50) NULL DEFAULT NULL AFTER `category_id`;

	ALTER TABLE `tbl_item_info`
        CHANGE COLUMN `thumb_pic_url` `thumb_pic_url` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_department_id`,
        CHANGE COLUMN `description` `description` VARCHAR(200) NULL DEFAULT NULL  AFTER `thumb_pic_url`,
        CHANGE COLUMN `standard` `standard` VARCHAR(100) NULL DEFAULT NULL  AFTER `description`,
        CHANGE COLUMN `parts` `parts` VARCHAR(100) NULL DEFAULT NULL  AFTER `standard`,
        CHANGE COLUMN `sale_price` `sale_price` DECIMAL(10,2) NULL AFTER `parts`;

------------------------------------王健 2024/8/5 END--------------------------------------


------------------------------------余建明 2024/8/08 BEGIN--------------------------------------
--粉丝见面会详情表新增未成交数据和下次邀约数据
ALTER TABLE `amiyadb`.`tbl_fans_meeting_details` 
ADD COLUMN `hospital_member_card_id`  VARCHAR(100) NULL AFTER `is_need_hospital_help`;
------------------------------------余建明 2024/8/08 END--------------------------------------


------------------------------------王健 2024/8/19 BEGIN--------------------------------------

--助理业绩目标添加线索登记量目标
ALTER TABLE `tbl_employee_performance_target`
	ADD COLUMN `clues_register_target` INT NOT NULL DEFAULT 0 AFTER `new_customer_visit_target`;

------------------------------------王健 2024/8/19 END--------------------------------------

------------------------------------王健 2024/8/19 BEGIN--------------------------------------
--商品编号字段加长
ALTER TABLE `tbl_item_info`
	CHANGE COLUMN `other_app_item_id` `other_app_item_id` VARCHAR(1000) NULL DEFAULT NULL COLLATE 'utf8mb4_unicode_ci' AFTER `app_type`;


------------------------------------王健 2024/8/19 BEGIN--------------------------------------


------------------------------------余建明 2024/8/21 BEGIN--------------------------------------
--助理薪资模块新增线索与加v完成奖励金额
ALTER TABLE `amiyadb`.`tbl_customer_service_compensation` 
ADD COLUMN `addclue_complete_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cooperation_live_anchor_to_hospital_price`,
ADD COLUMN `addwechat_complete_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `addclue_complete_price`;
------------------------------------余建明 2024/8/21 END--------------------------------------

------------------------------------余建明 2024/8/28 BEGIN--------------------------------------
--助理薪资模块新增老带新奖励金额
ALTER TABLE `amiyadb`.`tbl_customer_service_compensation` 
ADD COLUMN `old_take_newcustomer_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `addwechat_complete_price`;


--机构-三方平台编码表加入主外键关联关系
ALTER TABLE `amiyadb`.`tbl_hospital_contentplatform_code` 
ADD INDEX `fk_hospitalcontentplatformcode_hospitalinfo_idx` (`hospital_id` ASC) VISIBLE,
ADD INDEX `fk_hospitalcontentplatformcode_thirdpartcontentplatforminfo_idx` (`third_part_contentplatform` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_hospital_contentplatform_code` 
ADD CONSTRAINT `fk_hospitalcontentplatformcode_hospitalinfo`
  FOREIGN KEY (`hospital_id`)
  REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_hospitalcontentplatformcode_thirdpartcontentplatforminfo`
  FOREIGN KEY (`third_part_contentplatform`)
  REFERENCES `amiyadb`.`tbl_third_part_contentplatform_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  --手动添加三方平台数据
INSERT INTO `amiyadb`.`tbl_third_part_contentplatform_info` (`id`, `name`, `create_date`, `valid`) VALUES ('0fca2b4b-c023-4f7d-9675-b6acf8fd8b31', '朗姿', '2024-08-09', true);

--手动添加朗姿code
INSERT INTO `amiyadb`.`tbl_hospital_contentplatform_code` (`id`, `hospital_id`, `third_part_contentplatform`, `code`, `create_date`, `valid`) VALUES ('0fca2b4b-c023-4f7d-9675-b6acf8fd8b39', '45', '0fca2b4b-c023-4f7d-9675-b6acf8fd8b31', '6406', '2024-08-28', true);
------------------------------------余建明 2024/8/28 END--------------------------------------



------------------------------------余建明 2024/9/3 BEGIN--------------------------------------
--三方平台添加访问地址和签名
ALTER TABLE `amiyadb`.`tbl_third_part_contentplatform_info` 
ADD COLUMN `api_url` VARCHAR(300) NULL AFTER `delete_date`,
ADD COLUMN `sign` VARCHAR(100) NULL AFTER `api_url`;

--派单列表新增是否指定医院账户和医院账户id
ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `is_specify_hospital_employee` BIT(1) NOT NULL DEFAULT 0 AFTER `is_repeat_profundity_order`,
ADD COLUMN `hospital_emp_id` INT NOT NULL DEFAULT 0 AFTER `is_specify_hospital_employee`;


------------------------------------余建明 2024/9/5 END--------------------------------------
------------------------------------王健 2024/9/2 BEGIN--------------------------------------

----小黄车登记添加加v截图和线索截图
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `add_wechat_picture` VARCHAR(100) NULL DEFAULT NULL AFTER `belong_channel`,
	ADD COLUMN `clue_picture` VARCHAR(100) NULL DEFAULT NULL AFTER `add_wechat_picture`;
---添加加v人
ALTER TABLE `tbl_shopping_cart_registration`
	ADD COLUMN `add_wechat_empid` INT NULL DEFAULT NULL AFTER `clue_picture`;


------------------------------------王健 2024/9/2 END--------------------------------------
--------------------------------------------------------------------------------------------------------以上部分已更新到线上--------------------------------------

------------------------------------余建明 2024/9/11 BEGIN--------------------------------------
--小黄车登记列表新增“是否为日不落直播”
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_ribuluo_living` BIT(1) NOT NULL DEFAULT 0 AFTER `add_wechat_empid`;

update amiyadb.tbl_shopping_cart_registration set is_ribuluo_living=true where source=11;

--订单列表新增“是否为日不落直播”
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_ribuluo_living` BIT(1) NOT NULL DEFAULT 0 AFTER `consulting_content2`;

update amiyadb.tbl_shopping_cart_registration set is_ribuluo_living=true where customer_source=11;
------------------------------------余建明 2024/9/11 END--------------------------------------

