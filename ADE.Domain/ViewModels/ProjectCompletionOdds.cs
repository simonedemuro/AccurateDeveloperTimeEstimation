using System;
using System.Collections.Generic;
using System.Text;

namespace ADE.Domain.ViewModels
{
    public class ProjectCompletionOdds
    {
        public string Likelihood;
        public double Days;

        public ProjectCompletionOdds()
        {

        }

        public ProjectCompletionOdds(string likelihood, double odds)
        {
            Likelihood = likelihood;
            Days = odds;
        }
    }
}
