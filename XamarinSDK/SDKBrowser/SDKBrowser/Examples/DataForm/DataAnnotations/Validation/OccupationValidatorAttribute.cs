﻿using Telerik.XamarinForms.Common.DataAnnotations;

namespace SDKBrowser.Examples.DataForm.DataAnnotations.Validation
{
    // >> dataform-dataannotations-validation-gendervalidationattribute
    public class OccupationValidatorAttribute : ValidatorBaseAttribute
    {
        public OccupationValidatorAttribute()
        {
            this.NegativeFeedback = "Occupation must be specified";
        }

        protected override bool ValidateCore(object value)
        {
            return (Occupation)value != Occupation.Unspecified;
        }
    }
    // << dataform-dataannotations-validation-gendervalidationattribute
}
