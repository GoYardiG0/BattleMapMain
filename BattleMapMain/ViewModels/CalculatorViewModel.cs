using BattleMapMain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleMapMain.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
    //    private string firstVal;
    //    public string FirstVal
    //    {
    //        get
    //        {
    //            return this.firstVal;
    //        }
    //        set
    //        {
    //            this.firstVal = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string secondVal;
    //    public string SecondVal
    //    {
    //        get
    //        {
    //            return this.secondVal;
    //        }
    //        set
    //        {
    //            this.secondVal = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string op;
    //    public string Op
    //    {
    //        get
    //        {
    //            return this.op;
    //        }
    //        set
    //        {
    //            this.op = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string result;
    //    public string Result
    //    {
    //        get
    //        {
    //            return this.result;
    //        }
    //        set
    //        {
    //            this.result = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private BattleMapWebAPIProxy service;
    //    public CalculatorViewModel(BattleMapWebAPIProxy calcService)
    //    {
    //        SolveCommand = new Command(Solve);
    //        service = calcService;
    //    }
    //    public ICommand SolveCommand { get; set; }

    //    async void Solve()
    //    {
    //        int val1 = 0, val2 = 0;
    //        if (!int.TryParse(this.FirstVal, out val1))
    //        {
    //            ReportError();
    //            return;
    //        }
    //        if (!int.TryParse(this.SecondVal, out val2))
    //        {
    //            ReportError();
    //            return;
    //        }
    //        if (this.Op.Length != 1)
    //        {
    //            ReportError();
    //            return;
    //        }
    //        Exercise ex = new Exercise()
    //        {
    //            FirstVal = val1,
    //            SecondVal = val2,
    //            Op = this.Op[0]
    //        };

    //        ExerciseResult exerciseResult = await service.SolvePostAsync(ex);

    //        if (exerciseResult.Success)
    //        {
    //            Result = exerciseResult.Result.ToString();
    //        }
    //        else
    //        {
    //            Result = "Error Occured!";
    //        }
    //    }

    //    private void ReportError()
    //    {
    //        Result = "Bad Inputs! Fix and Try Again!";
    //    }

    }
}
