pipeline {
  agent any
  stages {
    stage('init') {
      steps {
        echo '"Clean workspace(${WORK_SPACE})"'
        dir(path: '"${WORK_SPACE}"')
        sh 'git clean -f -d -x -e /Library/'
      }
    }

  }
  environment {
    WORK_SPACE = '${WORKSPACE}'.replace("\\", "/")
  }
}