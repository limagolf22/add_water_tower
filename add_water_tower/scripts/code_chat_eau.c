#include <stdio.h>

typedef struct {
    char  id[50];
    float lat;
    float lon;
    float taille;
} Chateau;

char filename_r[]="../list_water_tower.csv";
char filename_w[]="../water_tower_package/source/water_tower.xml";

char tampon[200];

float get_lat(char coord[]);
float get_lon(char coord[]);

int main() {
    Chateau chateau;
    chateau.taille=1.0;
    FILE * file_r =NULL;
    FILE * file_w = NULL;
    file_r = fopen (filename_r, "r");
    file_w = fopen (filename_w, "w");
    printf("debut du code \n");
    if (file_r ==NULL) {
        printf("fichier manquant ou mal defini\n");
        return(1);
    }

    if (file_w ==NULL) {
        printf("fichier non cree\n");
        return(1);
    }

    fprintf(file_w,"<?xml version=\"1.0\"?>\n<FSData version=\"9.0\">");

    int is_deg=0;
    char coord_lat[50];
    char coord_lon[50];
    printf("l'insertion des coordonnees se fera en degres ?(y/n) : ");
    if (getchar()=='y') {
        is_deg=1;      
    }

    int i=1;
    while (fgets(tampon,200,file_r)!=NULL) {
        printf("entree boucle %s\n",tampon);
        chateau.id[0]='\0';
        chateau.lat=0.0;
        chateau.lon=0.0;
        chateau.taille=1.0;
        if (is_deg) {
            if (sscanf(tampon,"%[^;];%[^;];%[^;];%f",chateau.id,coord_lat,coord_lon,&(chateau.taille))!=4) {
                printf("deg dit : chateau %i incomplet\n",i);
            };
            chateau.lat=get_lat(coord_lat);
            chateau.lon=get_lon(coord_lon);
        }
        else {
            int check_confo=1;
            int k=0;
            while(tampon[k]!='\0'){
                if (tampon[k]==';') {
                    check_confo=0;
                }
                if (tampon[k]==',') {
                    tampon[k]='.';
                }
                k++;
            }
            if (check_confo) {
                printf("probleme de synthaxe, verifier le fichier .csv\n");
                return 1;
            }
            if (sscanf(tampon,"%[^;];%f;%f;%f",chateau.id,&(chateau.lat),&(chateau.lon),&(chateau.taille))!=4) {
                printf("chateau %i incomplet\n",i);
            };
        }
        fprintf(file_w,"\n\t<!--SceneryObject name: Water_Tower_FR-->\n\t<SceneryObject lat=\"%f\" lon=\"%f\" alt=\"0.00000000000000\" pitch=\"0.000068\" bank=\"-0.000068\" heading=\"-179.999991\" imageComplexity=\"VERY_SPARSE\" altitudeIsAgl=\"TRUE\" snapToGround=\"TRUE\" snapToNormal=\"FALSE\">\n\t\t<LibraryObject name=\"{93EE3F27-3429-4CC7-A9CC-0FB5ED33AFC2}\" scale=\"%f\"/>\n\t</SceneryObject>",chateau.lat,chateau.lon,chateau.taille);    
        printf("fin boucle %i\n",i);
        i++;
    }

    fprintf(file_w,"\n</FSData>");
    fclose(file_r);
    fclose(file_w); 

    printf("importation terminee !");
    return 0;
    
}

float get_lat(char coord[]) {
    int a,b,c;
    char d;
    sscanf(coord,"%i%*[^0-9]%i%*[^0-9]%i%*[^A-Z]%c",&a,&b,&c,&d);
   // printf("%i %i %i %c\n",a,b,c,d);
    if (d=='N') {
        return (a+b/60+c/3600);
    }
    else {
        return -(a+b/60+c/3600);
    }   
}

float get_lon(char coord[]) {
    int a,b,c;
    char d;
    sscanf(coord,"%i%*[^0-9]%i%*[^0-9]%i%*[^A-Z]%c",&a,&b,&c,&d);
  //  printf("%i %i %i %c\n",a,b,c,d);
    if (d=='E') {
        return (a+b/60+c/3600);
    }
    else {
        return -(a+b/60+c/3600);
    }   
}

  