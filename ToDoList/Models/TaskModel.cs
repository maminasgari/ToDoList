using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class TaskModel
{
    [Key]
    [Required]  
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
    [StringLength(50,ErrorMessage = "اندازه متن باید بین 1 تا 50 کرکتر باشد",MinimumLength = 1)]
    [Display(Name = "عنوان")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
    [StringLength(100, ErrorMessage = "اندازه متن باید بین 5 تا 100 کرکتر باشد", MinimumLength = 5)]
    [Display(Name = "توضیحات")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "وضعیت task را مشخص کنید")]
    [Display(Name = "وضعیت task")]
    public bool IsCompleted { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "فرمت تاریخ باید yyyy-mm-dd باشد")]
    [Display(Name = "تاریخ انمام")]
    public DateTime DueDate { get; set; }
}