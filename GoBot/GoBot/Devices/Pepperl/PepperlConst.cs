using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    public class PepperlConst
    {
        public const String CmdReboot = "reboot_device";
        public const String CmfFactoryReset = "factory_reset";
        public const String CmdHandleUdp = "request_handle_udp";
        public const String CmdHandleTcp = "request_handle_tcp";
        public const String CmdProtocolInfo = "get_protocol_info";
        public const String CmdFeedWatchdog = "feed_watchdog";
        public const String CmdListParameters = "list_parameters";
        public const String CmdGetParameter = "get_parameter";
        public const String CmdSetParameter = "set_parameter";
        public const String CmdResetParameter = "reset_parameter";
        public const String CmdReleaseHandle = "release_handle";
        public const String CmdStartScan = "start_scanoutput";
        public const String CmdStopScan = "stop_scanoutput";
        public const String CmdGetScanConfig = "get_scanoutput_config";
        public const String CmdSetScanConfig = "set_scanoutput_config";

        public const String ParamVendor = "vendor";
        public const String ParamProduct = "product";
        public const String ParamPart = "part";
        public const String ParamSerial = "serial";
        public const String ParamRevisionFw = "revision_fw";
        public const String ParamRevisionHw = "revision_hw";
        public const String ParamMaxConnections = "max_connections";
        public const String ParamFeatureFlags = "feature_flags";
        public const String ParamRadialRangeMin = "radial_range_min";
        public const String ParamRadialRangeMax = "radial_range_max";
        public const String ParamRadialResolution = "radial_resolution";
        public const String ParamAngularFov = "angular_fov";
        public const String ParamAngularResolution = "angular_resolution";
        public const String ParamScanFrequencyMin = "scan_frequency_min";
        public const String ParamScanFrequencyMax = "scan_frequency_max";
        public const String ParamSamplingRateMin = "sampling_rate_min";
        public const String ParamSamplingRateMax = "sampling_rate_max";
        public const String ParamSamplesPerScan = "samples_per_scan";
        public const String ParamScanFrequencyMeasured = "scan_frequency_measured";
        public const String ParamStatusFlags = "status_flags";
        public const String ParamLoadIndication = "load_indication";
        public const String ParamDeviceFamily = "device_family";
        public const String ParamMacAddress = "mac_address";
        public const String ParamIpModeCurrent = "ip_mode_current";
        public const String ParamIpAddressCurrent = "ip_address_current";
        public const String ParamSubnetMaskCurrent = "subnet_mask_current";
        public const String ParamGatewayCurrent = "gateway_current";
        public const String ParamSystemTimeRaw = "system_time_raw";
        public const String ParamUserTag = "user_tag";
        public const String ParamUserNotes = "user_notes";
        public const String ParamEmitterType = "emitter_type";
        public const String ParamUptime = "up_time";
        public const String ParamPowerCycles = "power_cycles";
        public const String ParamOperationTime = "operation_time";
        public const String ParamOperationTimeScaled = "operation_time_scaled";
        public const String ParamTemperatureCurrent = "temperature_current";
        public const String ParamTemperatureMin = "temperature_min";
        public const String ParamTemperatureMax = "temperature_max";
        public const String ParamHmiHardBitmap = "hmi_static_logo";
        public const String ParamHmiSoftBitmap = "hmi_application_bitmap";
        public const String ParamHmiHardText1 = "hmi_static_text_1";
        public const String ParamHmiHardText2 = "hmi_static_text_2";
        public const String ParamHmiSoftText1 = "hmi_application_text_1";
        public const String ParamHmiSoftText2 = "hmi_application_text_2";
        public const String ParamFilterWidth = "filter_width";
        public const String ParamFilterMaximumMargin = "filter_maximum_margin";
        public const String ParamUdpAddress = "address";
        public const String ParamUdpPort = "port";
        public const String ParamUdpWatchdogTimeout = "watchdogtimeout";
        public const String ParamUdpPacketCrc = "packet_crc";
        public const String ParamUdpStartAngle = "start_angle";
        public const String ParamUdpPointsCount = "max_num_points_scan";
        public const String ParamUdpSkipScans = "skip_scans";
        public const String ParamUdpHandle = "handle";
        public const String ParamTcpAddress = "address";
        public const String ParamTcpPort = "port";
        public const String ParamTcpPacketCrc = "packet_crc";
        public const String ParamTcpStartAngle = "start_angle";
        public const String ParamTcpPointsCount = "max_num_points_scan";
        public const String ParamTcpSkipScans = "skip_scans";
        public const String ParamTcpHandle = "handle";
        public const String ParamProtocolName = "protocol_name";
        public const String ParamProtocolVersionMajor = "version_major";
        public const String ParamProtocolVersionMinor = "version_minor";
        public const String ParamProtocolCommands = "commands";
        public const String ParamErrorCode = "error_code";
        public const String ParamErrorText = "error_text";
        public const String ParamContaminationDetectionWarnings = "lcm_sector_warn_flags";
        public const String ParamContaminationDetectionErrors = "lcm_sector_error_flags";
        public const String ParamContaminationDetectionPeriod = "lcm_detection_period";
        public const String ParamFeedWatchdogHandle = "handle";

        public const String ParamUdpWatchdog = "watchdog";
        public const String ValueUdpWatchdogOn = "on";
        public const String ValueUdpWatchdogOff = "off";

        public const String ParamTcpWatchdog = "watchdog";
        public const String ValueTcpWatchdogOn = "on";
        public const String ValueTcpWatchdogOff = "off";
        
        public const String ParamIpMode = "ip_mode";
        public const String ValueIpModeStatic = "static";
        public const String ValueIpModeAuto = "autoip";
        public const String ValueIpModeDhcp = "dhcp";

        public const String ParamIpAddress = "ip_address";
        public const String ParamSubnetMask = "subnet_mask";
        public const String ParamGateway = "gateway";
        public const String ParamScanFrequency = "scan_frequency";

        public const String ParamScanDirection = "scan_direction";
        public const String ValueScanDirectionClockwise = "cw";
        public const String ValueScanDirectionCounterClockwise = "ccw";

        public const String ParamHmiMode = "hmi_display_mode";
        public const String ValueHmiModeOff = "off";
        public const String ValueHmiModeHardLogo = "static_logo";
        public const String ValueHmiModeHardText = "static_text";
        public const String ValueHmiModeBargraphDistance = "bargraph_distance";
        public const String ValueHmiModeBargraphEcho = "bargraph_echo";
        public const String ValueHmiModeBargraphReflector = "bargraph_reflector";
        public const String ValueHmiModeSoftBitmap = "application_bitmap";
        public const String ValueHmiModeSoftText = "application_text";

        public const String ParamHmiLanguage = "hmi_language";
        public const String ValueHmiLanguageEnglish = "engligh";
        public const String ValueHmiLanguageGerman = "german";

        public const String ParamHmiButtonLock = "hmi_button_lock";
        public const String ValueHmiButtonLockOn = "on";
        public const String ValueHmiButtonLockOff = "off";

        public const String ParamHmiParameterLock = "hmi_parameter_lock";
        public const String ValueHmiParameterLockOn = "on";
        public const String ValueHmiParameterLockOff = "off";

        public const String ParamLocatorIndication = "locator_indication";
        public const String ValueLocatorIndicationLockOn = "on";
        public const String ValueLocatorIndicationOff = "off";
        
        public const String ParamOperatingMode = "operating_mode";
        public const String ValueOperatingModeMeasure = "measure";
        public const String ValueOperatingModeOff = "emitter_off";

        public const String ParamFilterType = "filter_type";
        public const String ValueFilterTypeNone = "none";
        public const String ValueFilterTypeAverage = "average";
        public const String ValueFilterTypeMedian = "median";
        public const String ValueFilterTypeMaximum = "maximum";
        public const String ValueFilterTypeRemission = "remission";

        public const String ParamFilterErrorHandling = "filter_error_handling";
        public const String ValueFilterErrorHandlingStrict = "strict";
        public const String ValueFilterErrorHandlingTolerant = "tolerant";

        public const String ParamFilterRemissionThreshold = "filter_remission_threshold";
        public const String ValueFilterRemissionThresholdDiffuseLow = "diffuse_low";
        public const String ValueFilterRemissionThresholdDiffuseHigh = "diffuse_high";
        public const String ValueFilterRemissionThresholdReflectorMin = "reflector_min";
        public const String ValueFilterRemissionThresholdReflectorLow = "reflector_low";
        public const String ValueFilterRemissionThresholdReflectorStd = "reflector_std";
        public const String ValueFilterRemissionThresholdReflectorHigh = "reflector_high";
        public const String ValueFilterRemissionThresholdReflectorMax = "reflector_max";

        public const String ParamUdpPacketType = "packet_type";
        public const String ValueUdpPacketTypeDistance = "A";
        public const String ValueUdpPacketTypeDistanceAmplitude = "B";
        public const String ValueUdpPacketTypeDistanceAmplitudeCompact = "C";

        public const String ParamTcpWatchdogTimeout = "watchdogtimeout";

        public const String ParamTcpPacketType = "packet_type";
        public const String ValueTcpPacketTypeDistance = "A";
        public const String ValueTcpPacketTypeDistanceAmplitude = "B";
        public const String ValueTcpPacketTypeDistanceAmplitudeCompact = "C";

        public const String ParamContaminationDetectionSensivity = "lcm_detection_sensitivity";
        public const String ValueContaminationDetectionSensivityDisabled = "disabled";
        public const String ValueContaminationDetectionSensivityLow = "low";
        public const String ValueContaminationDetectionSensivityMedium = "medium";
        public const String ValueContaminationDetectionSensivityHigh = "high";

        public const String ParamContaminationDetectionSectorEnable = "lcm_sector_enable";
        public const String ValueContaminationDetectionSectorEnableOn = "on";
        public const String ValueContaminationDetectionSectorEnableOff = "off";

        public const int FlagStatusInitialization = 1 << 00;
        public const int FlagStatusscanOutputMuted = 1 << 02;
        public const int FlagStatusUnstableRotation = 1 << 03;
        public const int FlagStatusDeviceWarning = 1 << 08;
        public const int FlagStatusLensContaminationWarning = 1 << 09;
        public const int FlagStatusLowTemperatureWarning = 1 << 10;
        public const int FlagStatusHighTemperatureWarning = 1 << 11;
        public const int FlagStatusDeviceOverloadWarning = 1 << 12;
        public const int FlagStatusDeviceError = 1 << 16;
        public const int FlagStatusLensContaminationError = 1 << 17;
        public const int FlagStatusLowTemperatureError = 1 << 18;
        public const int FlagStatusHighTemperatureError = 1 << 19;
        public const int FlagStatusDeviceOverloadError = 1 << 20;
        public const int FlagStatusDeviceDefect = 1 << 30;

        public const int ErrorSuccess = 0;
        public const int ErrorUnknownArgument = 100;
        public const int ErrorUnknownParameter = 110;
        public const int ErrorInvalidHandle = 120;
        public const int ErrorArgumentMissing = 130;
        public const int ErrorInvalidValue = 200;
        public const int ErrorOutOfRangeValue = 210;
        public const int ErrorReadOnly = 220;
        public const int ErrorMemory = 230;
        public const int ErrorAlreadyInUse = 240;
        public const int ErrorInternal = 333;
    }
}
