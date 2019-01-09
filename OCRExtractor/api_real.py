
# coding: utf-8

# In[ ]:

import os
import subprocess


import flask
from flask import request, jsonify

app = flask.Flask(__name__)
app.config["DEBUG"] = True

# Create some test data for our catalog in the form of a list of dictionaries.


@app.route('/', methods=['GET'])
def home():
    return '''<h1>Digital Mail Room Home</h1>
<p>Please Select the following URLs to start or stop the process</p>'''

@app.route('/api/request', methods=['GET'])
def api_id():
    
    if 'id' in request.args and (request.args['id'] == 'start' or request.args['id'] == 'stop'):
        if(request.args['id'] == 'start'):
            output = str(subprocess.check_output("python helloworld.py", shell=True))
            
            return '''<h1>Digital Mail Room Output</h1><p>'''+output[2:len(output)-5]+'''</p>'''
        elif (request.args['id'] == 'stop'):
            os.system("quit()")
        else:
            pass
    else:
        return '''<h1>404 Error</h1>
<p>Error: No parameter is provided. Please specify a parameter like start or stop .</p>'''

app.run()

