namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgressInfo iStreamProgressInfo;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgressInfo iStreamProgressInfo)
        {
            this.iStreamProgressInfo = iStreamProgressInfo;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProgressInfo.BytesSent * 100) /
                this.iStreamProgressInfo.Length;
        }
    }
}
