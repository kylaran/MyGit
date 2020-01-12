 var app = new Vue ({
	el:'#app',
	data:{
		url :"",
		cleanUrl:""
	},
	methods: {
			CleanerUrl: function(){
				this.cleanUrl =this.url.replace(/^https?:\/\//, '').replace(/\/$/,'')
			},
			CountDown: function(){
				this.count -=1
			}
			
		}
})  