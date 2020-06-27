using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {

        public PragimTech.Components.ConfirmBase DeleteConfirmation { get; set; }
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected bool IsSelected { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }

        protected async Task Delete_Click()
        {

            DeleteConfirmation.Show();

            //await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            //await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);

            //NavigationManager.NavigateTo("/", true);
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                
            }
        }


    }
}
