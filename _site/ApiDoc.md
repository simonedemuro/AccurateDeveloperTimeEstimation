# Api

Here is the list of available methods:

1. [How likely](###LikelihoodCompleteWithinDays) is to complete a task within x days?

2. [Get Task/Project Completion](###GetProjectCompletionOdds) probability distribution by tree valued estimations 

### LikelihoodCompleteWithinDays?

Not Implemented ...Yet

### GetProjectCompletionOdds

This methods returns the probability distribution of project completion.

URL: <endpoint>/api/values

Body (application/json):

` [{
  	"Optimistic":1,
  	"Neutral":3,
  	"Pessimistic":12}
]`

![screen](<https://raw.githubusercontent.com/simonedemuro/AccurateDeveloperTimeEstimation/master/_site/projCompletionApi.png>)