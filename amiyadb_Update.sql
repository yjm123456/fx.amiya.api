

----------------------------------------------王健 2024/1/4 BEGIN----------------------------------------
---员工表添加提成信息
ALTER TABLE `tbl_amiya_employee`
	ADD COLUMN `new_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `bind_base_live_anchor_id`,
	ADD COLUMN `old_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `new_customer_commission`,
	ADD COLUMN `inspection_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `old_customer_commission`;

---助理薪资表添加字段
ALTER TABLE `tbl_customer_service_compensation`
	ADD COLUMN `salary` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `remark`,
	ADD COLUMN `customer_service_performance` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `salary`,
	ADD COLUMN `to_hospital_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `customer_service_performance`,
	ADD COLUMN `to_hospital_rate_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `to_hospital_rate`,
	ADD COLUMN `repeat_purchases_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `to_hospital_rate_reword`,
	ADD COLUMN `repeat_purchases_rate_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `repeat_purchases_rate`,
	ADD COLUMN `new_customer_to_hospital_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `repeat_purchases_rate_reword`,
	ADD COLUMN `old_customer_to_hospital_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `new_customer_to_hospital_reword`,
	ADD COLUMN `target_finish_reword` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `old_customer_to_hospital_reword`,
	ADD COLUMN `other_chargebacks` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `target_finish_reword`;

----------------------------------------------王健 2024/1/4 END----------------------------------------
 
----------------------------------------------余建明 2024/1/4 BEGIN----------------------------------------
--助理薪资审核新增提成点数与提成业绩
 ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `performance_percent` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `customer_service_compensation_id`,
ADD COLUMN `customer_service_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `performance_percent`;
----------------------------------------------余建明 2024/1/4 END----------------------------------------




------------------------------------------王健  2024/1/18 BEGIN------------------------------------------
---职位信息添加字段
ALTER TABLE `tbl_amiya_position_info`
	ADD COLUMN `read_self_liveanchor_data` BIT NOT NULL AFTER `read_live_anchor_data`,
	ADD COLUMN `read_cooperate_liveanchor_data` BIT NOT NULL AFTER `read_self_liveanchor_data`,
	ADD COLUMN `read_take_goods_data` BIT NOT NULL AFTER `read_cooperate_liveanchor_data`;

------------------------------------------王健  2024/1/18 END------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


----------------------------------------王健  2024/1/19 BEGIN------------------------------------------


---员工表添加行政客服提成信息
ALTER TABLE `tbl_amiya_employee`
	ADD COLUMN `administrative_inspection_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `inspection_commission`,
	ADD COLUMN `cooperate_liveanchor_new_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `administrative_inspection_commission`,
	ADD COLUMN `cooperate_liveanchor_old_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `cooperate_liveanchor_new_customer_commission`;
	ADD COLUMN `tmall_order_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `cooperate_liveanchor_old_customer_commission`;


----------------------------------------王健  2024/1/19 END------------------------------------------


----------------------------------------------余建明 2024/1/22 BEGIN----------------------------------------
--对账单审核记录新增行政客服审核薪资模块数据
ALTER TABLE `amiyadb`.`tbl_recommand_document_settle` 
ADD COLUMN `check_type` INT NOT NULL DEFAULT 0 AFTER `compensation_check_state`,
ADD COLUMN `is_inspect_performance` BIT(1) NOT NULL DEFAULT 0 AFTER `check_belong_empid`,
ADD COLUMN `inspect_empid` INT NULL AFTER `is_inspect_performance`,
ADD COLUMN `inspect_percent` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_empid`,
ADD COLUMN `inspect_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_empid`,
ADD COLUMN `inspect_customer_service_compensation_id` VARCHAR(50) NULL AFTER `customer_service_compensation_id`,
ADD COLUMN `customer_service_order_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `inspect_customer_service_compensation_id`;
----------------------------------------------余建明 2024/1/22 END----------------------------------------