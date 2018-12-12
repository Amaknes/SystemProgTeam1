using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Rqt_SQL
    {

        public static string ListeEtapeCommande(int IdCommand)
        {
            return "SELECT OrderStep, TimeTask, NameTask FROM dbo.Preparation, dbo.CommandLine, dbo.step, dbo.Task, dbo.Compose WHERE dbo.CommandLine.IDCommand = "+ IdCommand + " AND dbo.Preparation.TypePreparation = dbo.CommandLine.TypePreparation AND dbo.Preparation.IDPreparation = dbo.CommandLine.IDPreparation AND dbo.Preparation.IDPreparation = dbo.step.IDPreparation AND dbo.Preparation.TypePreparation = dbo.Step.TypePreparationAND db o.Step.IDStep = dbo.Compose.IDStep AND dbo.Compose.IDTask = dbo.Task.IDTask";
        }

        public static string LieuDeStockageIngredient(int IdCommand)
        {
            return "SELECT NameIngredient, TypeIngredient FROM dbo.Ingredient, dbo.Require, dbo.step, dbo.Preparation, dbo.CommandLine WHERE dbo.CommandLine.IDCommand = "+ IdCommand + " AND dbo.Preparation.TypePreparation = dbo.CommandLine.TypePreparation AND dbo.Preparation.IDPreparation = dbo.CommandLine.IDPreparation AND dbo.Preparation.IDPreparation = dbo.step.IDPreparation AND dbo.Preparation.TypePreparation = dbo.Step.TypePreparation AND dbo.Step.IDStep = dbo.Require.IDStep AND dbo.Require.IDIngredient = dbo.Ingredient.IDIngredient";
        }

       
    }
}