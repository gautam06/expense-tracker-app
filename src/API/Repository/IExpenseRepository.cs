﻿using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;

namespace ExpenseTrackerAPI.Repository;

public interface IExpenseRepository
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
    Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto);
    Task<ExpenseDto> GetExpenseByIdAsync(int id);
    Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto);
    Task<bool> DeleteExpenseAsync(int id);
	Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId);
	
	    
	Task<IEnumerable<ExpensesByCategoryDto>> GetExpensesByUserIdAsync(int userId);

}