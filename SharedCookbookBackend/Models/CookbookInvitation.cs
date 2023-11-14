using SharedCookbookBackend.Enums;
using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class CookbookInvitation
{
    public int CookbookInvitationId { get; set; }

    public int? SenderPersonId { get; set; }

    public int? RecipientPersonId { get; set; }

    public int? CookbookId { get; set; }

    public CookbookInvitationStatus CookbookInvitationStatus { get; set; }

    public DateTime CookbookInvitationDate { get; set; }

    public DateTime? ResponseDate { get; set; }

    public virtual Cookbook? Cookbook { get; set; }

    public virtual Person? RecipientPerson { get; set; }

    public virtual Person? SenderPerson { get; set; }
}
