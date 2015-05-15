using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHTManager
{
    public class PHTMDataPoint
    {
        private double dataTime;
        public double DataTime
        {
            get { return dataTime; }
            set { dataTime = value; }
        }
        
        private int pPG1;
        public int PPG1
        {
            get { return pPG1; }
            set { pPG1 = value; }
        }

        public ushort CPRaw = 512;
        public ushort CPZero = 512;
        public ushort CPGain = 38;

        private int cP;
        public int CP
        {
            get
            {
                cP = (CPRaw - CPZero) * CPGain / 100;
                return cP;
            }
            set
            {
                cP = value;
            }
        }

        int cuffPID = 127;
        public int CuffPID
        {
            get { return cuffPID; }
            set { cuffPID = value; }
        }

        int bPM = 60;
        public int BPM
        {
            get { return bPM; }
            set { bPM = value; }
        }

        int iBI = 600;
        public int IBI
        {
            get { return iBI; }
            set { iBI = value; }
        }

        private int targetCuffPressure = 90;
        public int TargetCuffPressure
        {
            get { return targetCuffPressure; }
            set
            {
                targetCuffPressure = value;
            }
        }

        public int TargetCuffPressureToRaw()
        {
            return (targetCuffPressure * 100) / CPGain + CPZero;
        }

        // Default constructor
        public PHTMDataPoint()
        {

        }

        public PHTMDataPoint(double time, int ppg1, int cp)
        {
            dataTime = time;
            pPG1 = ppg1;
            cP = cp;
        }
    }

    public class PHTMDataPoints : List<PHTMDataPoint>
    {
        public PHTMDataPoint dataPoint { get; set; }
    }
}
