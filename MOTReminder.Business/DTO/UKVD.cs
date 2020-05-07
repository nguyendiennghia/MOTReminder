using System;
using System.Collections.Generic;
using System.Text;

namespace MOTReminder.Business.DTO
{
    public class ExtraInformation
    {
    }

    public class BillingAccount
    {

        public string AccountType { get; set; }

        public double AccountBalance { get; set; }

        public double TransactionCost { get; set; }

        public ExtraInformation ExtraInformation { get; set; }
    }

    public class DataKeys
    {

        public string Vrm { get; set; }
    }

    public class Request
    {

        public string RequestGuid { get; set; }

        public string PackageId { get; set; }

        public int PackageVersion { get; set; }

        public int ResponseVersion { get; set; }

        public DataKeys DataKeys { get; set; }
    }

    public class Lookup
    {

        public string StatusCode { get; set; }

        public string StatusMessage { get; set; }

        //public IList AdviceTextList { get; set; }
    }

    public class StatusInformation
    {

        public Lookup Lookup { get; set; }
    }

    public class Dimensions
    {

        public double? UnladenWeight { get; set; }

        public object RigidArtic { get; set; }

        public object BodyShape { get; set; }

        public object PayloadVolume { get; set; }

        public object PayloadWeight { get; set; }

        public double? Height { get; set; }

        public int? NumberOfDoors { get; set; }

        public object NumberOfSeats { get; set; }

        public double? KerbWeight { get; set; }

        public object GrossTrainWeight { get; set; }

        public double? FuelTankCapacity { get; set; }

        public object LoadLength { get; set; }

        public object DataVersionNumber { get; set; }

        public double? WheelBase { get; set; }

        public double? CarLength { get; set; }

        public double? Width { get; set; }

        public object NumberOfAxles { get; set; }

        public double? GrossVehicleWeight { get; set; }

        public object GrossCombinedWeight { get; set; }
    }

    public class EuroNcap
    {

        public double? Child { get; set; }

        public double? Adult { get; set; }

        public double? Pedestrian { get; set; }
    }

    public class Safety
    {

        public EuroNcap EuroNcap { get; set; }
    }

    public class Engine
    {

        public string FuelCatalyst { get; set; }

        public object Stroke { get; set; }

        public object PrimaryFuelFlag { get; set; }

        public int ValvesPerCylinder { get; set; }

        public string Aspiration { get; set; }

        public string FuelSystem { get; set; }

        public int NumberOfCylinders { get; set; }

        public string CylinderArrangement { get; set; }

        public string ValveGear { get; set; }

        public object Location { get; set; }

        public object Description { get; set; }

        public object Bore { get; set; }

        public object Make { get; set; }

        public string FuelDelivery { get; set; }
    }

    public class ElectricVehicleBattery
    {

        public object Capacity { get; set; }

        public object ChargePort { get; set; }

        public object ChargeTime { get; set; }

        public object Type { get; set; }
    }

    public class General
    {

        public Engine Engine { get; set; }

        public object PowerDelivery { get; set; }

        public object TypeApprovalCategory { get; set; }

        public ElectricVehicleBattery ElectricVehicleBattery { get; set; }

        public string SeriesDescription { get; set; }

        public string DriverPosition { get; set; }

        public string DrivingAxle { get; set; }

        public object DataVersionNumber { get; set; }

        public string EuroStatus { get; set; }

        public bool IsLimitedEdition { get; set; }
    }

    public class Torque
    {

        public double FtLb { get; set; }

        public double Nm { get; set; }

        public double Rpm { get; set; }
    }

    public class Power
    {

        public double Bhp { get; set; }

        public object Rpm { get; set; }

        public object Kw { get; set; }
    }

    public class MaxSpeed
    {

        public object Kph { get; set; }

        public double Mph { get; set; }
    }

    public class Acceleration
    {

        public double Mph { get; set; }

        public object Kph { get; set; }

        public double ZeroTo60Mph { get; set; }

        public object ZeroTo100Kph { get; set; }
    }

    public class Performance
    {

        public Torque Torque { get; set; }

        public object NoiseLevel { get; set; }

        public object DataVersionNumber { get; set; }

        public Power Power { get; set; }

        public MaxSpeed MaxSpeed { get; set; }

        public double Co2 { get; set; }

        public object Particles { get; set; }

        public Acceleration Acceleration { get; set; }
    }

    public class ExtraUrban
    {

        public double Lkm { get; set; }

        public double Mpg { get; set; }
    }

    public class UrbanCold
    {

        public double Lkm { get; set; }

        public double Mpg { get; set; }
    }

    public class Combined
    {

        public double Lkm { get; set; }

        public double Mpg { get; set; }
    }

    public class Consumption
    {

        public ExtraUrban ExtraUrban { get; set; }

        public UrbanCold UrbanCold { get; set; }

        public Combined Combined { get; set; }
    }

    public class TechnicalDetails
    {

        public Dimensions Dimensions { get; set; }

        public Safety Safety { get; set; }

        public General General { get; set; }

        public Performance Performance { get; set; }

        public Consumption Consumption { get; set; }
    }

    public class Mvris
    {

        public string ModelCode { get; set; }

        public string MakeCode { get; set; }
    }

    public class Smmt
    {

        public string Make { get; set; }

        public Mvris Mvris { get; set; }

        public string Trim { get; set; }

        public string Range { get; set; }
    }

    public class Dvla
    {

        public string Model { get; set; }

        public string Make { get; set; }
    }

    public class ClassificationDetails
    {

        public Smmt Smmt { get; set; }

        public Dvla Dvla { get; set; }
    }

    public class FirstYear
    {

        public object SixMonth { get; set; }

        public double TwelveMonth { get; set; }
    }

    public class YearTwoToSix
    {

        public object TwelveMonth { get; set; }

        public object SixMonth { get; set; }
    }

    public class PremiumVehicle
    {

        public YearTwoToSix YearTwoToSix { get; set; }
    }

    public class Standard
    {

        public object SixMonth { get; set; }

        public double TwelveMonth { get; set; }
    }

    public class VedRate
    {

        public FirstYear FirstYear { get; set; }

        public PremiumVehicle PremiumVehicle { get; set; }

        public Standard Standard { get; set; }
    }

    public class MotVed
    {

        public VedRate VedRate { get; set; }

        public double VedCo2Emissions { get; set; }

        public object MotDue { get; set; }

        public string VedBand { get; set; }

        public object VedCo2Band { get; set; }

        public object TaxDue { get; set; }

        public object Message { get; set; }

        public object VehicleStatus { get; set; }
    }

    public class VehicleStatus
    {

        public MotVed MotVed { get; set; }

        public string NextMotDueDate { get; set; }

        public int DaysUntilNextMotIsDue { get; set; }
    }

    public class V5CCertificateList
    {

        public DateTime CertificateDate { get; set; }
    }

    public class KeeperChangesList
    {

        public DateTime DateOfTransaction { get; set; }

        public int NumberOfPreviousKeepers { get; set; }

        public DateTime DateOfLastKeeperChange { get; set; }
    }

    public class VehicleHistory
    {

        public int V5CCertificateCount { get; set; }

        public int PlateChangeCount { get; set; }

        public int NumberOfPreviousKeepers { get; set; }

        public IList<V5CCertificateList> V5CCertificateList { get; set; }

        public int KeeperChangesCount { get; set; }

        public int VicCount { get; set; }

        public object ColourChangeCount { get; set; }

        public object ColourChangeList { get; set; }

        public IList<KeeperChangesList> KeeperChangesList { get; set; }

        //public IList PlateChangeList { get; set; }

        public object VicList { get; set; }
    }

    public class VehicleRegistration
    {

        public DateTime DateOfLastUpdate { get; set; }

        public string Colour { get; set; }

        public string VehicleClass { get; set; }

        public bool CertificateOfDestructionIssued { get; set; }

        public string EngineNumber { get; set; }

        public string EngineCapacity { get; set; }

        public object TransmissionCode { get; set; }

        public bool Exported { get; set; }

        public string YearOfManufacture { get; set; }

        public string WheelPlan { get; set; }

        public object DateExported { get; set; }

        public bool Scrapped { get; set; }

        public object Transmission { get; set; }

        public DateTime DateFirstRegisteredUk { get; set; }

        public string Model { get; set; }

        public int GearCount { get; set; }

        public bool ImportNonEu { get; set; }

        public object PreviousVrmGb { get; set; }

        public double GrossWeight { get; set; }

        public string DoorPlanLiteral { get; set; }

        public string MvrisModelCode { get; set; }

        public string Vin { get; set; }

        public string Vrm { get; set; }

        public DateTime DateFirstRegistered { get; set; }

        public object DateScrapped { get; set; }

        public string DoorPlan { get; set; }

        public string YearMonthFirstRegistered { get; set; }

        public string VinLast5 { get; set; }

        public bool VehicleUsedBeforeFirstRegistration { get; set; }

        public double MaxPermissibleMass { get; set; }

        public string Make { get; set; }

        public string MakeModel { get; set; }

        public string TransmissionType { get; set; }

        public int SeatingCapacity { get; set; }

        public string FuelType { get; set; }

        public double Co2Emissions { get; set; }

        public bool Imported { get; set; }

        public string MvrisMakeCode { get; set; }

        public object PreviousVrmNi { get; set; }

        public object VinConfirmationFlag { get; set; }
    }

    public class SmmtDetails
    {

        public string Range { get; set; }

        public string FuelType { get; set; }

        public string EngineCapacity { get; set; }

        public string MarketSectorCode { get; set; }

        public string CountryOfOrigin { get; set; }

        public string ModelCode { get; set; }

        public string ModelVariant { get; set; }

        public object DataVersionNumber { get; set; }

        public int NumberOfGears { get; set; }

        public double NominalEngineCapacity { get; set; }

        public string MarqueCode { get; set; }

        public string Transmission { get; set; }

        public string BodyStyle { get; set; }

        public string VisibilityDate { get; set; }

        public string SysSetupDate { get; set; }

        public string Marque { get; set; }

        public string CabType { get; set; }

        public object TerminateDate { get; set; }

        public string Series { get; set; }

        public int NumberOfDoors { get; set; }

        public string DriveType { get; set; }
    }

    public class AnnotationDetailsList
    {

        public string Type { get; set; }

        public string Text { get; set; }

        public bool Dangerous { get; set; }
    }

    public class RecordList
    {

        public string TestNumber { get; set; }

        public string TestDate { get; set; }

        public string ExpiryDate { get; set; }

        public string TestResult { get; set; }

        public int OdometerReading { get; set; }

        public string OdometerUnit { get; set; }

        public int OdometerInKilometers { get; set; }

        public int OdometerInMiles { get; set; }

        public int MileageSinceLastPass { get; set; }

        public bool MileageAnomalyDetected { get; set; }

        public int? DaysSinceLastPass { get; set; }

        public int? DaysSinceLastTest { get; set; }

        public int? DaysOutOfMot { get; set; }

        public bool IsRetest { get; set; }

        public int AdvisoryNoticeCount { get; set; }

        public int DangerousFailureCount { get; set; }

        public int MajorFailureCount { get; set; }

        public bool HasExtensionPeriod { get; set; }

        public string ExtensionPeriodReason { get; set; }

        public int? ExtensionPeriodAdditionalDays { get; set; }

        public string ExtensionPeriodOriginalDueDate { get; set; }

        public string ExtensionPeriodDvsaDueDate { get; set; }

        //public IList<AdvisoryNoticeList> AdvisoryNoticeList { get; set; }

        //public IList<FailureReasonList> FailureReasonList { get; set; }

        public IList<AnnotationDetailsList> AnnotationDetailsList { get; set; }
    }

    public class MotHistory
    {

        public int RecordCount { get; set; }

        public IList<RecordList> RecordList { get; set; }
    }

    public class DataItems
    {

        public TechnicalDetails TechnicalDetails { get; set; }

        public ClassificationDetails ClassificationDetails { get; set; }

        public VehicleStatus VehicleStatus { get; set; }

        public VehicleHistory VehicleHistory { get; set; }

        public VehicleRegistration VehicleRegistration { get; set; }

        public SmmtDetails SmmtDetails { get; set; }

        public MotHistory MotHistory { get; set; }
    }

    public class Response
    {

        public string StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public StatusInformation StatusInformation { get; set; }

        public DataItems DataItems { get; set; }
    }

    public class VehicleDataV2
    {

        public BillingAccount BillingAccount { get; set; }

        public Request Request { get; set; }

        public Response Response { get; set; }
    }
}
