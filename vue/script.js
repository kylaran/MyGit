 var app = new Vue ({
	el:'#app',
	data:{
		count :0
	},
	methods: {
			CountUp: function(){
				this.count +=1
			},
			CountDown: function(){
				this.count -=1
			}
			
		}
})  