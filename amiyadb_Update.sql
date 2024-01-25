

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
	ADD COLUMN `cooperate_liveanchor_old_customer_commission` DECIMAL(10,2) NULL DEFAULT 0 AFTER `cooperate_liveanchor_new_customer_commission`,
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


----------------------------------------王健  2024/1/25 BEGIN------------------------------------------

---直播前月目标添加抖音 线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `tiktok_clues_target` INT NOT NULL DEFAULT 0 AFTER `tik_tok_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_tiktok_clues` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues_target`,
	ADD COLUMN `tiktok_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_clues`,
	ADD COLUMN `tiktok_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues_complete_rate`,
	ADD COLUMN `cumulative_tiktok_increase_fans` INT NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_target`,
	ADD COLUMN `tiktok_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_increase_fans`,
	ADD COLUMN `tiktok_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_tiktok_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees_target`,
	ADD COLUMN `tiktok_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_increase_fans_fees`;



---直播前月目标添加小红书  线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `xiaohongshu_showcase_income_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income_target`,
	ADD COLUMN `xiaohongshu_showcase_income_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_showcase_income`,
	ADD COLUMN `xiaohongshu_clues_target` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_clues` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues_target`,
	ADD COLUMN `xiaohongshu_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_clues`,
	ADD COLUMN `xiaohongshu_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_increase_fans` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_target`,
	ADD COLUMN `xiaohongshu_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_increase_fans`,
	ADD COLUMN `xiaohongshu_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees_target`,
	ADD COLUMN `xiaohongshu_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_increase_fans_fees`;


---直播前月目标添加抖音  线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `video_showcase_income_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_video_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_income_target`,
	ADD COLUMN `video_showcase_income_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_showcase_income`,
	ADD COLUMN `video_clues_target` INT NOT NULL DEFAULT 0 AFTER `video_showcase_income_complete_rate`,
	ADD COLUMN `cumulative_video_clues` INT NOT NULL DEFAULT 0 AFTER `video_clues_target`,
	ADD COLUMN `video_clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_clues`,
	ADD COLUMN `video_increase_fans_target` INT NOT NULL DEFAULT 0 AFTER `video_clues_complete_rate`,
	ADD COLUMN `cumulative_video_increase_fans` INT NOT NULL DEFAULT 0 AFTER `video_increase_fans_target`,
	ADD COLUMN `video_increase_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_increase_fans`,
	ADD COLUMN `video_increase_fans_fees_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_complete_rate`,
	ADD COLUMN `cumulative_video_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees_target`,
	ADD COLUMN `video_increase_fans_fees_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_increase_fans_fees`;


---直播前抖音日运营数据添加 线索,涨粉,涨粉费用字段
ALTER TABLE `tbl_beforeliving_tiktok_daily_target`
	ADD COLUMN `tiktok_clues` INT NOT NULL DEFAULT 0 AFTER `tiktok_showcase_income`,
	ADD COLUMN `tiktok_increase_fans` INT NOT NULL DEFAULT 0 AFTER `tiktok_clues`,
	ADD COLUMN `tiktok_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans`;


---直播前视频号日运营数据添加 线索,涨粉,涨粉费用,橱窗收入字段
ALTER TABLE `tbl_beforeliving_video_daily_target`
	ADD COLUMN `video_clues` INT NOT NULL DEFAULT 0 AFTER `send_num`,
	ADD COLUMN `video_increase_fans` INT NOT NULL DEFAULT 0 AFTER `video_clues`,
	ADD COLUMN `video_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans`,
	ADD COLUMN `video_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees`;


---直播前小红书日运营数据添加 线索,涨粉,涨粉费用,橱窗收入字段
ALTER TABLE `tbl_beforeliving_xiaohongshu_daily_target`
	ADD COLUMN `xiaohongshu_clues` INT NOT NULL DEFAULT 0 AFTER `record_date`,
	ADD COLUMN `xiaohongshu_increase_fans` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_clues`,
	ADD COLUMN `xiaohongshu_increase_fans_fees` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans`,
	ADD COLUMN `xiaohongshu_showcase_income` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_increase_fans_fees`;

--直播月目标添加抖音,小红书,视频号 橱窗付费
ALTER TABLE `tbl_liveanchor_monthly_target_before_living`
	ADD COLUMN `tiktok_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_increase_fans_fees_complete_rate`,
	ADD COLUMN `cumulative_tiktok_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_showcase_fee_target`,
	ADD COLUMN `tiktok_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_tiktok_showcase_fee`,
	ADD COLUMN `xiaohongshu_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_showcase_fee_complete_rate`,
	ADD COLUMN `cumulative_xiaohongshu_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_fee_target`,
	ADD COLUMN `xiaohongshu_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_xiaohongshu_showcase_fee`,
	ADD COLUMN `video_showcase_fee_target` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_fee_complete_rate`,
	ADD COLUMN `cumulative_video_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_fee_target`,
	ADD COLUMN `video_showcase_fee_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `cumulative_video_showcase_fee`;

--直播前抖音日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_tiktok_daily_target`
	ADD COLUMN `tiktok_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `tiktok_increase_fans_fees`;

--直播前视频号日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_video_daily_target`
	ADD COLUMN `video_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `video_showcase_income`;

--直播前小红书日运营数据添加橱窗付费
ALTER TABLE `tbl_beforeliving_xiaohongshu_daily_target`
	ADD COLUMN `xiaohongshu_showcase_fee` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `xiaohongshu_showcase_income`;


	----------------------------------------王健  2024/1/25 END------------------------------------------