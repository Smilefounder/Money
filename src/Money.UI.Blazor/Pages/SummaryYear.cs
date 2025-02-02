﻿using Microsoft.AspNetCore.Components;
using Money.Models;
using Money.Models.Queries;
using Neptuo.Logging;
using Neptuo.Models.Keys;
using Neptuo.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Pages
{
    [Route("/{Year:int}")]
    public class SummaryYear : Summary<YearModel>
    {
        [Parameter]
        protected int? Year { get; set; }

        public SummaryYear() 
            => SubTitle = "Per-year summary of outcomes in categories";

        protected override void ClearPreviousParameters() 
            => Year = null;

        protected override YearModel CreateSelectedItemFromParameters()
        {
            Log.Debug($"CreateSelectedItemFromParameters(Year='{Year}')");

            if (Year != null)
                return new YearModel(Year.Value);
            else
                return null;
        }

        protected override IQuery<List<YearModel>> CreateItemsQuery()
            => new ListYearWithOutcome();

        protected override IQuery<Price> CreateTotalQuery(YearModel item)
            => new GetTotalYearOutcome(item);

        protected override IQuery<List<CategoryWithAmountModel>> CreateCategoriesQuery(YearModel item)
            => new ListYearCategoryWithOutcome(item);

        protected override bool IsContained(DateTime changed)
            => Items.Contains(changed);

        protected override string UrlSummary(YearModel item)
            => Navigator.UrlSummary(item);

        protected override void OpenOverview(YearModel item)
            => Navigator.OpenOverview(item);

        protected override void OpenOverview(YearModel item, IKey categorykey)
            => Navigator.OpenOverview(item, categorykey);
    }
}
