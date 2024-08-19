

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
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


------------------------------------王健 2024/8/19 BEGIN--------------------------------------

--助理业绩目标添加线索登记量目标
ALTER TABLE `tbl_employee_performance_target`
	ADD COLUMN `clues_register_target` INT NOT NULL DEFAULT 0 AFTER `new_customer_visit_target`;

------------------------------------王健 2024/8/19 END--------------------------------------