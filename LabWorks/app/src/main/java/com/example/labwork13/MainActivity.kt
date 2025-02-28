package com.example.labwork13

import android.icu.text.ListFormatter.Width
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.material3.Button
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.BlurEffect
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.layout.VerticalAlignmentLine
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.labwork13.ui.theme.LabWork13Theme
import org.intellij.lang.annotations.JdkConstants.HorizontalAlignment

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            LabWork13Theme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Greeting(
                        nameGroup = "испп21",
                        modifier = Modifier.padding(innerPadding)
                    )
                    Task2(
                        nameGroup = "испп21"
                    )
                }
            }
        }
    }
}

@Composable
fun Greeting(nameGroup: String, modifier: Modifier = Modifier) {
    Text(
        text = "Привет, $nameGroup!",
        modifier = modifier
    )
}

@Composable
fun Task2(nameGroup: String){
    Text(
        text = nameGroup,
        fontSize = 28.sp,
        modifier = Modifier
            .background(Color.Gray)
            .padding(20.dp),
        color = Color.Blue
        )
}

@Composable
fun Task3Column(){
    Column(horizontalAlignment = Alignment.CenterHorizontally) {
        Text(
            text = "Добро пожаловать",
            fontSize = 28.sp,
            modifier = Modifier
                .padding(20.dp),
            color = Color.Blue
        )
        Button(onClick = {}, ){
            Text("OK")
        }
    }
}

@Composable
fun Task3Row(){
    Row(verticalAlignment = Alignment.CenterVertically) {
        Text(
            text = "Добро пожаловать",
            fontSize = 28.sp,
            modifier = Modifier
                .padding(20.dp),
            color = Color.Blue
        )
        Button(onClick = {}) {
            Text("OK")
        }
    }
}

@Composable
fun Task3Box() {
    Box (modifier = Modifier.fillMaxWidth()) {
        Text(
            text = "Добро пожаловать",
            fontSize = 28.sp,
            modifier = Modifier
                .padding(20.dp)
                .align(Alignment.CenterStart)
        )
        Button(onClick = {}, modifier = Modifier.align(Alignment.CenterEnd)) {
            Text("OK")
        }
    }
}

@Composable
fun Task4_1(){
    Box(modifier = Modifier
        .fillMaxSize()
     ){
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.TopStart)
            .background(Color.Red),

        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.TopCenter)
            .background(Color.Cyan)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.TopEnd)
            .background(Color.DarkGray)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.CenterStart)
            .background(Color.Green)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.CenterEnd)
            .background(Color.Magenta)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.BottomStart)
            .background(Color.Blue)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.BottomCenter)
            .background(Color.Gray)
        )
        Box(modifier = Modifier
            .size(100.dp)
            .align(Alignment.BottomEnd)
            .background(Color.Yellow)
        )
        Box(modifier = Modifier
            .size(300.dp, 750.dp)
            .align(Alignment.Center)
            .background(Color.Black)
        )
    }
}

@Composable
fun Task4_2(){
    Column(modifier =  Modifier.fillMaxWidth()) {
        Text("5%",
            fontSize = 28.sp,
            modifier = Modifier
                .weight(0.05f)
                .background(Color.Red)
                .fillMaxWidth(),
            color = Color.White
        )
        Text("15%",
            fontSize = 28.sp,
            modifier = Modifier
                .weight(0.15f)
                .background(Color.Green)
                .fillMaxWidth()
        )
        Text("30%",
            fontSize = 28.sp,
            modifier = Modifier
                .weight(0.30f)
                .background(Color.Blue)
                .fillMaxWidth(),
            color = Color.White
            )
        Text("50%",
            fontSize = 28.sp,
            modifier = Modifier
                .weight(0.50f)
                .background(Color.Yellow)
                .fillMaxWidth()
            )
    }
}


@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    LabWork13Theme {
        Greeting("испп21")
    }
}

@Preview(showBackground = true)
@Composable
fun Task2Preview() {
    LabWork13Theme {
        Task2("испп21")
    }
}

@Preview(showBackground = true)
@Composable
fun Task3ColumnPreview() {
    LabWork13Theme {
        Task3Column()
    }
}

@Preview(showBackground = true)
@Composable
fun Task3RowPreview() {
    LabWork13Theme {
        Task3Row()
    }
}

@Preview(showBackground = true)
@Composable
fun Task3BoxPreview() {
    LabWork13Theme {
        Task3Box()
    }
}

@Preview(showBackground = true)
@Composable
fun Task4_1Preview() {
    LabWork13Theme {
        Task4_1()
    }
}

@Preview(showBackground = true)
@Composable
fun Task4_2Preview() {
    LabWork13Theme {
        Task4_2()
    }
}

