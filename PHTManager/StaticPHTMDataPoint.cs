using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHTManager
{
    class StaticPHTMDataPoint
    {
        public static ushort CPZero = 29;       // Cuff pressure offset in ADC counts
        public static double CPGain = 22.7692;  // 0.01 mmHg /count from measurements on 11 Nov 2017

        public static ushort CPMin = 0;         // Minimum cuff pressure setting
        public static ushort CPMax = 200;       // Maximum cuff pressure setting

        public StaticPHTMDataPoint()
        {
            targetCuffPressure = 90;
        }

        private ushort targetCuffPressureRaw = 0;
        public ushort TargetCuffPressureRaw { get => targetCuffPressureRaw; }

        private ushort targetCuffPressure = 90;    // Target cuff pressure in mmHg
        public ushort TargetCuffPressure
        {
            get { return targetCuffPressure; }
            set
            {
                targetCuffPressure = value;
                targetCuffPressureRaw = (ushort)((targetCuffPressure * 100.0) / CPGain);
                targetCuffPressureRaw += CPZero;
            }
        }

        private Byte pumpSpeed = 127;
        public Byte PumpSpeed { get => pumpSpeed; set => pumpSpeed = value; }

        private ushort fillRateRaw = 0;     // Cuff fill rate in ADC counts / min
        public ushort FillRateRaw { get => fillRateRaw; }
        private ushort fillRate = 30;       // Cuff fill rate in mmHg / min
        public ushort FillRate
        {
            get => fillRate;
            set
            {
                fillRate = value;
                fillRateRaw = RateToRaw(fillRate);
            }
        }

        private ushort bleedRateRaw = 0;    // Cuff bleed rate in ADC counts / min
        public ushort BleedRateRaw { get => bleedRateRaw; }
        private ushort bleedRate = 30;      // Cuff bleed rate in mmHg / min
        public ushort BleedRate
        {
            get => bleedRate;
            set
            {
                bleedRate = value;
                bleedRateRaw = RateToRaw(bleedRate);
            }
        }

        private Byte cPTRaw = 0;                    // Cuff pressure tolerance in ADC counts
        public byte CPTRaw { get => cPTRaw; }
        private Byte cuffPressureTolerance;         // Cuff pressure tolerance in mmHg
        public byte CuffPressureTolerance
        {
            get => cuffPressureTolerance;
            set
            {
                cuffPressureTolerance = value;
                cPTRaw = (Byte)RateToRaw(cuffPressureTolerance);
            }
        }

        private Byte sSCPTRaw = 0;                          // State switch cuff pressure tolerance in ADC counts
        public byte SSCPTRaw { get => sSCPTRaw; }
        private Byte stateSwitchCuffPressureTolerance = 0;  // State switch cuff pressure tolerance in mmHg
        public byte StateSwitchCuffPressureTolerance
        {
            get => stateSwitchCuffPressureTolerance;
            set
            {
                stateSwitchCuffPressureTolerance = value;
                sSCPTRaw = (Byte)RateToRaw(stateSwitchCuffPressureTolerance);
            }
        }

        private Byte maintenencePumpSpeed = 0x20;
        public byte MaintenencePumpSpeed { get => maintenencePumpSpeed; set => maintenencePumpSpeed = value; }


        public ushort RateToRaw(ushort rate)
        {
            return (ushort)(rate * 100.0 / CPGain);
        }
    }
}
