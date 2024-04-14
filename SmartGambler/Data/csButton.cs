using System.ComponentModel;
using Young.Setting;

namespace SmartGambler.Data
{
	public class csButton : csAutoSaveLoad
    {
        private static csButton instance;
        public static csButton GetInstance()
        {
            if (instance == null) instance = new csButton();
            return instance;
        }
        private csButton()
        {
            Load();
        }

        [DisplayName("라운드 종료 키")]
        [Description("라운드가 종료되었을때 사용되는 키입니다. 모든 정보가 초기화 됩니다.")]
        [Number(NumberAttributeEnum.HookerKeyCode)]
        [DefaultValue(111)]
		public int RoundClear { get; set; }

		[DisplayName("발사 수 돌리기 키")]
		[Description("발사한 탄으 숫자를 되돌리는대 사용됩니다. 해당하는 공간은 알수 없음으로 초기화 됩니다.")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(106)]
		public int ReturnBulletCount { get; set; }

		[DisplayName("실탄 발사 키")]
        [Description("실탄이 발사 되었을때 사용됩니다.")]
        [Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(100)]
		public int OutBulletReally { get; set; }

		[DisplayName("공포탄 발사 키")]
		[Description("공포탄이 발사 되었을때 사용됩니다.")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(97)]
		public int OutBulletLie { get; set; }

		[DisplayName("남은 실탄 수 증가")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(101)]
		public int CountReallyUp { get; set; }

		[DisplayName("남은 실탄 수 감소")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(98)]
		public int CountReallyDown { get; set; }

		[DisplayName("남은 공포탄 수 증가")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(102)]
		public int CountLieUp { get; set; }

		[DisplayName("남은 공포탄 수 감소")]
		[Number(NumberAttributeEnum.HookerKeyCode)]
		[DefaultValue(99)]
		public int CountLieDown { get; set; }
	}
}
