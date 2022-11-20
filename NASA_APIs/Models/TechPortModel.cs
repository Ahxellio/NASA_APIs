using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NASA_APIs.Models
{
    public class TechPortModel
    {
        [JsonPropertyName("project")]
        public Project Project { get; set; }
    }
    public class CloseoutDocument
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("file")]
        public File File { get; set; }

        [JsonPropertyName("transitionId")]
        public int TransitionId { get; set; }

        [JsonPropertyName("fileId")]
        public int FileId { get; set; }
    }

    public class ContentType
    {
        [JsonPropertyName("lkuCodeId")]
        public int LkuCodeId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("lkuCodeTypeId")]
        public int LkuCodeTypeId { get; set; }

        [JsonPropertyName("lkuCodeType")]
        public LkuCodeType LkuCodeType { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Destination
    {
        [JsonPropertyName("lkuCodeId")]
        public int LkuCodeId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("lkuCodeTypeId")]
        public int LkuCodeTypeId { get; set; }

        [JsonPropertyName("lkuCodeType")]
        public LkuCodeType LkuCodeType { get; set; }
    }

    public class File
    {
        [JsonPropertyName("fileExtension")]
        public string FileExtension { get; set; }

        [JsonPropertyName("fileId")]
        public int FileId { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("fileSize")]
        public int FileSize { get; set; }

        [JsonPropertyName("objectId")]
        public int ObjectId { get; set; }

        [JsonPropertyName("objectType")]
        public ObjectType ObjectType { get; set; }

        [JsonPropertyName("objectTypeId")]
        public int ObjectTypeId { get; set; }

        [JsonPropertyName("fileSizeString")]
        public string FileSizeString { get; set; }
    }

    public class File2
    {
        [JsonPropertyName("fileExtension")]
        public string FileExtension { get; set; }

        [JsonPropertyName("fileId")]
        public int FileId { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("fileSize")]
        public int FileSize { get; set; }

        [JsonPropertyName("objectId")]
        public int ObjectId { get; set; }

        [JsonPropertyName("objectType")]
        public ObjectType ObjectType { get; set; }

        [JsonPropertyName("objectTypeId")]
        public int ObjectTypeId { get; set; }

        [JsonPropertyName("fileSizeString")]
        public string FileSizeString { get; set; }
    }

    public class LeadOrganization
    {
        [JsonPropertyName("canUserEdit")]
        public bool CanUserEdit { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("external")]
        public bool External { get; set; }

        [JsonPropertyName("linkCount")]
        public int LinkCount { get; set; }

        [JsonPropertyName("organizationId")]
        public int OrganizationId { get; set; }

        [JsonPropertyName("organizationName")]
        public string OrganizationName { get; set; }

        [JsonPropertyName("organizationType")]
        public string OrganizationType { get; set; }

        [JsonPropertyName("stateTerritory")]
        public StateTerritory StateTerritory { get; set; }

        [JsonPropertyName("stateTerritoryId")]
        public int StateTerritoryId { get; set; }

        [JsonPropertyName("msiData")]
        public MsiData MsiData { get; set; }

        [JsonPropertyName("setAsideData")]
        public List<string> SetAsideData { get; set; }

        [JsonPropertyName("ein")]
        public string Ein { get; set; }

        [JsonPropertyName("naorganization")]
        public bool Naorganization { get; set; }

        [JsonPropertyName("organizationTypePretty")]
        public string OrganizationTypePretty { get; set; }
    }

    public class LibraryItem
    {
        [JsonPropertyName("file")]
        public File File { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("libraryItemTypeId")]
        public int LibraryItemTypeId { get; set; }

        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        [JsonPropertyName("publishedDateString")]
        public string PublishedDateString { get; set; }

        [JsonPropertyName("contentType")]
        public ContentType ContentType { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }
    }

    public class LkuCodeType
    {
        [JsonPropertyName("codeType")]
        public string CodeType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class MsiData
    {
    }

    public class ObjectType
    {
        [JsonPropertyName("lkuCodeId")]
        public int LkuCodeId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("lkuCodeTypeId")]
        public int LkuCodeTypeId { get; set; }

        [JsonPropertyName("lkuCodeType")]
        public LkuCodeType LkuCodeType { get; set; }
    }

    public class PrimaryImage
    {
        [JsonPropertyName("file")]
        public File File { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("publishedDateString")]
        public string PublishedDateString { get; set; }
    }

    public class PrimaryTaxonomyNode
    {
        [JsonPropertyName("taxonomyNodeId")]
        public int TaxonomyNodeId { get; set; }

        [JsonPropertyName("taxonomyRootId")]
        public int TaxonomyRootId { get; set; }

        [JsonPropertyName("parentNodeId")]
        public int ParentNodeId { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("definition")]
        public string Definition { get; set; }

        [JsonPropertyName("exampleTechnologies")]
        public string ExampleTechnologies { get; set; }

        [JsonPropertyName("hasChildren")]
        public bool HasChildren { get; set; }

        [JsonPropertyName("hasInteriorContent")]
        public bool HasInteriorContent { get; set; }
    }

    public class PrincipalInvestigator
    {
        [JsonPropertyName("contactId")]
        public int ContactId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("fullNameInverted")]
        public string FullNameInverted { get; set; }

        [JsonPropertyName("middleInitial")]
        public string MiddleInitial { get; set; }

        [JsonPropertyName("primaryEmail")]
        public string PrimaryEmail { get; set; }

        [JsonPropertyName("publicEmail")]
        public bool PublicEmail { get; set; }

        [JsonPropertyName("nacontact")]
        public bool Nacontact { get; set; }
    }

    public class Program
    {
        [JsonPropertyName("acronym")]
        public string Acronym { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("programId")]
        public int ProgramId { get; set; }

        [JsonPropertyName("responsibleMd")]
        public ResponsibleMd ResponsibleMd { get; set; }

        [JsonPropertyName("responsibleMdId")]
        public int ResponsibleMdId { get; set; }

        [JsonPropertyName("stockImageFileId")]
        public int StockImageFileId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class ProgramDirector
    {
        [JsonPropertyName("contactId")]
        public int ContactId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("fullNameInverted")]
        public string FullNameInverted { get; set; }

        [JsonPropertyName("middleInitial")]
        public string MiddleInitial { get; set; }

        [JsonPropertyName("primaryEmail")]
        public string PrimaryEmail { get; set; }

        [JsonPropertyName("publicEmail")]
        public bool PublicEmail { get; set; }

        [JsonPropertyName("nacontact")]
        public bool Nacontact { get; set; }
    }

    public class ProgramExecutive
    {
        [JsonPropertyName("contactId")]
        public int ContactId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("fullNameInverted")]
        public string FullNameInverted { get; set; }

        [JsonPropertyName("middleInitial")]
        public string MiddleInitial { get; set; }

        [JsonPropertyName("primaryEmail")]
        public string PrimaryEmail { get; set; }

        [JsonPropertyName("publicEmail")]
        public bool PublicEmail { get; set; }

        [JsonPropertyName("nacontact")]
        public bool Nacontact { get; set; }
    }

    public class ProgramManager
    {
        [JsonPropertyName("contactId")]
        public int ContactId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("fullNameInverted")]
        public string FullNameInverted { get; set; }

        [JsonPropertyName("primaryEmail")]
        public string PrimaryEmail { get; set; }

        [JsonPropertyName("publicEmail")]
        public bool PublicEmail { get; set; }

        [JsonPropertyName("nacontact")]
        public bool Nacontact { get; set; }
    }

    public class Project
    {
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("primaryTaxonomyNodes")]
        public List<PrimaryTaxonomyNode> PrimaryTaxonomyNodes { get; set; }

        [JsonPropertyName("startTrl")]
        public int StartTrl { get; set; }

        [JsonPropertyName("currentTrl")]
        public int CurrentTrl { get; set; }

        [JsonPropertyName("endTrl")]
        public int EndTrl { get; set; }

        [JsonPropertyName("benefits")]
        public string Benefits { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("destinations")]
        public List<Destination> Destinations { get; set; }

        [JsonPropertyName("startYear")]
        public int StartYear { get; set; }

        [JsonPropertyName("startMonth")]
        public int StartMonth { get; set; }

        [JsonPropertyName("endYear")]
        public int EndYear { get; set; }

        [JsonPropertyName("endMonth")]
        public int EndMonth { get; set; }

        [JsonPropertyName("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonPropertyName("principalInvestigators")]
        public List<PrincipalInvestigator> PrincipalInvestigators { get; set; }

        [JsonPropertyName("programDirectors")]
        public List<ProgramDirector> ProgramDirectors { get; set; }

        [JsonPropertyName("programExecutives")]
        public List<ProgramExecutive> ProgramExecutives { get; set; }

        [JsonPropertyName("programManagers")]
        public List<ProgramManager> ProgramManagers { get; set; }

        [JsonPropertyName("libraryItems")]
        public List<LibraryItem> LibraryItems { get; set; }

        [JsonPropertyName("transitions")]
        public List<Transition> Transitions { get; set; }

        [JsonPropertyName("primaryImage")]
        public PrimaryImage PrimaryImage { get; set; }

        [JsonPropertyName("responsibleMd")]
        public ResponsibleMd ResponsibleMd { get; set; }

        [JsonPropertyName("program")]
        public Program Program { get; set; }

        [JsonPropertyName("leadOrganization")]
        public LeadOrganization LeadOrganization { get; set; }

        [JsonPropertyName("supportingOrganizations")]
        public List<SupportingOrganization> SupportingOrganizations { get; set; }

        [JsonPropertyName("statesWithWork")]
        public List<StatesWithWork> StatesWithWork { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("releaseStatusString")]
        public string ReleaseStatusString { get; set; }

        [JsonPropertyName("endDateString")]
        public string EndDateString { get; set; }

        [JsonPropertyName("startDateString")]
        public string StartDateString { get; set; }
    }

    public class ResponsibleMd
    {
        [JsonPropertyName("acronym")]
        public string Acronym { get; set; }

        [JsonPropertyName("canUserEdit")]
        public bool CanUserEdit { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("external")]
        public bool External { get; set; }

        [JsonPropertyName("linkCount")]
        public int LinkCount { get; set; }

        [JsonPropertyName("organizationId")]
        public int OrganizationId { get; set; }

        [JsonPropertyName("organizationName")]
        public string OrganizationName { get; set; }

        [JsonPropertyName("organizationType")]
        public string OrganizationType { get; set; }

        [JsonPropertyName("naorganization")]
        public bool Naorganization { get; set; }

        [JsonPropertyName("organizationTypePretty")]
        public string OrganizationTypePretty { get; set; }
    }

    

    public class StatesWithWork
    {
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("stateTerritoryId")]
        public int StateTerritoryId { get; set; }
    }

    public class StateTerritory
    {
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("stateTerritoryId")]
        public int StateTerritoryId { get; set; }
    }

    public class SupportingOrganization
    {
        [JsonPropertyName("acronym")]
        public string Acronym { get; set; }

        [JsonPropertyName("canUserEdit")]
        public bool CanUserEdit { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("external")]
        public bool External { get; set; }

        [JsonPropertyName("linkCount")]
        public int LinkCount { get; set; }

        [JsonPropertyName("organizationId")]
        public int OrganizationId { get; set; }

        [JsonPropertyName("organizationName")]
        public string OrganizationName { get; set; }

        [JsonPropertyName("organizationType")]
        public string OrganizationType { get; set; }

        [JsonPropertyName("stateTerritory")]
        public StateTerritory StateTerritory { get; set; }

        [JsonPropertyName("stateTerritoryId")]
        public int StateTerritoryId { get; set; }

        [JsonPropertyName("naorganization")]
        public bool Naorganization { get; set; }

        [JsonPropertyName("organizationTypePretty")]
        public string OrganizationTypePretty { get; set; }
    }

    public class Transition
    {
        [JsonPropertyName("transitionId")]
        public int TransitionId { get; set; }

        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("transitionDate")]
        public string TransitionDate { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("closeoutDocuments")]
        public List<CloseoutDocument> CloseoutDocuments { get; set; }

        [JsonPropertyName("infoText")]
        public string InfoText { get; set; }

        [JsonPropertyName("infoTextExtra")]
        public string InfoTextExtra { get; set; }

        [JsonPropertyName("dateText")]
        public string DateText { get; set; }
    }


}
