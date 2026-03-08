using System;
using System.Collections.Generic;

namespace bdDevCRM.FrontEnd.Entities;

public partial class CrmApplication
{
    public int ApplicationId { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int StateId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<CrmAdditionalInfo> CrmAdditionalInfo { get; set; } = new List<CrmAdditionalInfo>();

    public virtual ICollection<CrmApplicantCourse> CrmApplicantCourse { get; set; } = new List<CrmApplicantCourse>();

    public virtual ICollection<CrmApplicantInfo> CrmApplicantInfo { get; set; } = new List<CrmApplicantInfo>();

    public virtual ICollection<CrmApplicantReference> CrmApplicantReference { get; set; } = new List<CrmApplicantReference>();

    public virtual ICollection<CrmEducationHistory> CrmEducationHistory { get; set; } = new List<CrmEducationHistory>();

    public virtual ICollection<CrmGmatinformation> CrmGmatinformation { get; set; } = new List<CrmGmatinformation>();

    public virtual ICollection<CrmIeltsinformation> CrmIeltsinformation { get; set; } = new List<CrmIeltsinformation>();

    public virtual ICollection<CrmOthersInformation> CrmOthersInformation { get; set; } = new List<CrmOthersInformation>();

    public virtual ICollection<CrmPermanentAddress> CrmPermanentAddress { get; set; } = new List<CrmPermanentAddress>();

    public virtual ICollection<CrmPresentAddress> CrmPresentAddress { get; set; } = new List<CrmPresentAddress>();

    public virtual ICollection<CrmPteinformation> CrmPteinformation { get; set; } = new List<CrmPteinformation>();

    public virtual ICollection<CrmToeflinformation> CrmToeflinformation { get; set; } = new List<CrmToeflinformation>();

    public virtual ICollection<CrmWorkExperience> CrmWorkExperience { get; set; } = new List<CrmWorkExperience>();
}
